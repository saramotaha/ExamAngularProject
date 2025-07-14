import { Routes } from '@angular/router';
import { Home } from './Pages/home/home';
import { Login } from './Pages/login/login';
import { Register } from './Pages/register/register';
import { Exam } from './Pages/exam/exam';
import { AddExam } from './Components/add-exam/add-exam';
import { AddQuestion } from './Components/add-question/add-question';

export const routes: Routes = [
  {path: '', redirectTo: "Home", pathMatch: "full" },
  {path: 'Home',component:Home, pathMatch:"full"},
  {path: 'Login',component :Login, pathMatch:"full"},
  {path: 'Register',component :Register, pathMatch:"full"},
  {path: 'Exam',component :Exam, pathMatch:"full"},
  {path: 'AddExam',component :AddExam, pathMatch:"full"},
  {path: 'AddQuestion/:id',component :AddQuestion, pathMatch:"full"},
];
