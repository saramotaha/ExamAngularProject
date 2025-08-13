import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Home } from "./Pages/home/home";
import { Nav } from "./LayOut/nav/nav";
import { Footer } from "./LayOut/footer/footer";
import { ExamService } from './Services/exam-service';
import { error, log } from 'console';
import { Dashboard } from "./LayOut/dashboard/dashboard";
import { Login } from "./Pages/login/login";
import { Register } from "./Pages/register/register";

@Component({
  selector: 'app-root',
  imports: [ RouterOutlet],

  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App implements OnInit {
  protected title = 'ExamWebApp';
  flag: boolean=false;

  constructor(exam: ExamService ,private c:ChangeDetectorRef) {

    exam.GetAllExams().subscribe(
      {
      next: (res:any) => {
        console.log(res);
      }

    }

    )




  }
  ngOnInit(): void {
    this.flag = localStorage.getItem('token') != null ? true : false;
    console.log(this.flag);
    this.c.detectChanges();

  }
}
