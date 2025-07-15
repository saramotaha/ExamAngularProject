import { Component, OnInit } from '@angular/core';
import { RouterLink, RouterLinkActive } from '@angular/router';
import { Router } from 'express';
import { LoginService } from '../../Services/login-service';
import { FormControl, FormControlName, FormGroup, FormsModule, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-login',
  imports: [RouterLink , ReactiveFormsModule],
  templateUrl: './login.html',
  styleUrl: './login.css'
})
export class Login implements OnInit {

  constructor(private login: LoginService) { }
  loginForm! : FormGroup;

  ngOnInit(): void {

    this.loginForm = new FormGroup({

    email: new FormControl(''),
    passWord: new FormControl(''),
  })
    ;

  }







  LoginToDashBoard() {


    if (this.loginForm.valid) {

      this.login.loginToDashBoard(this.loginForm.value).subscribe({
        next: (response) => {

          console.log(response.token);
          localStorage.setItem("token", response.token);

        },

        error: (err) => {
          console.log(err);

        },
      })

    }







  }



}
