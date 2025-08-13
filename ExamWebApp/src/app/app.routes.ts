import { Routes } from '@angular/router';
import { Home } from './Pages/home/home';
import { Login } from './Pages/login/login';
import { Register } from './Pages/register/register';
import { Exam } from './Pages/exam/exam';
import { AddExam } from './Components/add-exam/add-exam';
import { AddQuestion } from './Components/add-question/add-question';
import { ShowExam } from './Components/show-exam/show-exam';
import { DashBoardHome } from './Components/dash-board-home/dash-board-home';
import { ShowStudentScores } from './Services/show-student-scores';
import { StudentsScores } from './Pages/students-scores/students-scores';
import { StudentScoreInHisExam } from './Pages/student-score-in-his-exam/student-score-in-his-exam';
import { Dashboard } from './LayOut/dashboard/dashboard';
import { adminAuthGuard } from './Guards/admin-auth-guard';
import { studentAuthGuard } from './Guards/student-auth-guard';



export const routes: Routes = [
  {path: '', redirectTo: "Login", pathMatch: "full" },
  {path: 'Home',component:Home, pathMatch:"full"},
  {path: 'Login',component :Login, pathMatch:"full"},
  {path: 'Register',component :Register, pathMatch:"full"},
  {
    path: 'Dashboard', component: Dashboard,
    children: [

  {path: '',redirectTo:'DashBoardHome', pathMatch:"full"},
  {path: 'Exam',component :Exam, pathMatch:"full"},
  {path: 'AddExam', canActivate:[adminAuthGuard], component :AddExam, pathMatch:"full"},
  {path: 'AddQuestion/:id', canActivate:[adminAuthGuard],component :AddQuestion, pathMatch:"full"},
  {path: 'ShowExam/:id',component :ShowExam, pathMatch:"full"},
  {path: 'DashBoardHome', canActivate:[adminAuthGuard],component :DashBoardHome, pathMatch:"full"},
  {path: 'StudentsScores' , canActivate:[adminAuthGuard],component :StudentsScores, pathMatch:"full"},
  {path: 'StudentScoreInHisExam', canActivate:[studentAuthGuard],component :StudentScoreInHisExam, pathMatch:"full"}

    ]
  }


];
