import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { RegisterService } from '../../Services/register-service';
import { IRegister } from '../../Interfaces/iregister';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './register.html',
  styleUrls: ['./register.css']
})
export class Register {
  form!: FormGroup;
  successMessage = '';
  errorMessage = '';

  constructor(private fb: FormBuilder, private registerService: RegisterService) {
    this.initializeForm();
  }
private initializeForm(): void {
  this.form = this.fb.group({
    Name: ['', Validators.required],
    Email: ['', [Validators.required, Validators.email]],
    Password: ['', [Validators.required, Validators.minLength(6)]],
    ConfirmPassword: ['', Validators.required],
    role: ['Student']
  });
}

register(): void {
  if (this.form.invalid) {
    this.form.markAllAsTouched();
    return;
  }

  // Create EXACT structure that matches UserRegisterDto
  var userData = {
    Name: this.form.value.Name,
    Email: this.form.value.Email,
    Password: this.form.value.Password,
    ConfirmPassword: this.form.value.ConfirmPassword,
    role: this.form.value.role // lowercase 'r'
  };

  console.log('Submitting:', userData); // Debug before sending
this.registerService.registerUser(userData).subscribe({
  next: (response) => {
    if (response.success) {
      this.successMessage = response.message;
      console.log('Registered user:', response.user);
      this.form.reset({ role: 'Student' });
    } else {
      this.errorMessage = response.message || 'Registration failed';
    }
  },
  error: (err) => {
    this.errorMessage = err.message;
    console.error('Registration error:', err);
  }
});

}

}