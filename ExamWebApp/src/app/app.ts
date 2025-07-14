import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Home } from "./Pages/home/home";
import { Nav } from "./LayOut/nav/nav";
import { Footer } from "./LayOut/footer/footer";
import { ExamService } from './Services/exam-service';
import { error, log } from 'console';

@Component({
  selector: 'app-root',
  imports: [Nav, Footer, RouterOutlet],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected title = 'ExamWebApp';

  constructor(exam: ExamService) {

    exam.GetAllExams().subscribe(
      {
      next: (res:any) => {
        console.log(res);
      }

    }

    )

  }
}
