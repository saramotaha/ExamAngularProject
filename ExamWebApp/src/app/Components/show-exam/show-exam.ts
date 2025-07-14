import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { GetQuestionsOfExam } from '../../Services/get-questions-of-exam';
import { ActivatedRoute } from '@angular/router';
import { IQuestion } from '../../Interfaces/iquestion';

@Component({
  selector: 'app-show-exam',
  imports: [],
  templateUrl: './show-exam.html',
  styleUrl: './show-exam.css'
})
export class ShowExam implements OnInit {

  responseBody!: IQuestion[];

  constructor(private http: HttpClient, private questions: GetQuestionsOfExam , private route:ActivatedRoute) { }



  ExamID!: number;



  ngOnInit(): void {
    this.ExamID = +this.route.snapshot.paramMap.get('id')!;
    this.questions.GetQuestionsByExamId(this.ExamID).subscribe({
      next: (response) => {

        this.responseBody = response;
        console.log(response);

      }
    });
  }







}
