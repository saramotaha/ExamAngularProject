import { Routes } from '@angular/router';
import { Home } from './Pages/home/home';
import { Login } from './Pages/login/login';
import { Register } from './Pages/register/register';

export const routes: Routes = [
  {path: '', redirectTo: "Home", pathMatch: "full" },
  {path: 'Home',component:Home, pathMatch:"full"},
  {path: 'Login',component :Login, pathMatch:"full"},
  {path: 'Register',component :Register, pathMatch:"full"},
];
