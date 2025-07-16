import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { RegisterService } from '../../Services/register-service';
import { IRegister } from '../../Interfaces/iregister';
import { Router } from '@angular/router';

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

  constructor(private fb: FormBuilder, private registerService: RegisterService  , private router: Router) {
    this.initializeForm();
  }
private initializeForm(): void {
  this.form = this.fb.group({
    Name: ['', Validators.required],
    Email: ['', [Validators.required, Validators.email]],
    Password: ['', [Validators.required, Validators.minLength(6)]],
    ConfirmPassword: ['', Validators.required],
    role: ['student']
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
    next: (res) => {
      this.successMessage = res.message || 'Registration successful!';
      this.errorMessage = '';
      setTimeout(() => {
        this.router.navigate(['/login']);
      }, 1500);
    },
    error: (err) => {
      console.error('Registration error:', err);
      this.errorMessage = err.message || 'Registration failed';
      this.successMessage = '';
    }
  });

}

}