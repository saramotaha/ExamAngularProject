import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { GetQuestionsOfExam } from '../../Services/get-questions-of-exam';
import { ActivatedRoute } from '@angular/router';
import { IQuestion } from '../../Interfaces/iquestion';
import { FormControl, FormGroup, FormsModule, NgModel, ReactiveFormsModule } from '@angular/forms';
import { IAnswer } from '../../Interfaces/ianswer';
import { CommonModule } from '@angular/common';
import { log } from 'node:console';
import { StudentExamService } from '../../Services/student-exam-service';
import { IStudentExam } from '../../Interfaces/istudent-exam';

@Component({
  selector: 'app-show-exam',
  imports: [FormsModule , CommonModule],
  standalone: true,
  templateUrl: './show-exam.html',
  styleUrl: './show-exam.css'
})
export class ShowExam implements OnInit {

  CorrectAnswer!: string[];
  responseBody!: IQuestion[];

  choices!: IAnswer[];

  constructor(private http: HttpClient, private questions: GetQuestionsOfExam , private route:ActivatedRoute  , private studentExam:StudentExamService) { }



  ExamID!: number;
  SubmitExamForm!: FormGroup;
  sum: number = 0;

  studExam!: IStudentExam;

  options!:[];


  ngOnInit(): void {
    this.ExamID = +this.route.snapshot.paramMap.get('id')!;
    this.questions.GetQuestionsByExamId(this.ExamID).subscribe({
      next: (response) => {

        this.responseBody = response;
        console.log(response);
        this.CorrectAnswer = new Array(this.responseBody.length).fill('');

        this.choices = response.choices

      }
    });







  //    this.SubmitExamForm = new FormGroup({

  //   text: new FormControl(`${this.responseBody[0].text} `),
  //   degree: new FormControl(`${this.responseBody[0].degree}`),
  //   optionA: new FormControl(``),
  //   optionB: new FormControl(``),
  //   optionC: new FormControl(''),




  // })




  }








  SubmitExam() {






    if(this.responseBody.length > 0) {

      //var answer=
       console.log(this.CorrectAnswer);
      for (let index = 0; index < this.responseBody.length; index++) {


        for (let i = 0; i < this.responseBody[index].choices.length; i++) {


          // let x =this.responseBody[index].


          console.log(this.responseBody[index].text);

          let x = this.CorrectAnswer[index];

          if(x==this.responseBody[index].choices.find(q=>q.isCorrect==true)?.answerText)
          // console.log(this.responseBody[index].choices[i].isCorrect);
          {

            console.log("done");

            this.sum += this.responseBody[index].degree;


             this.studExam = {
              score: this.sum,
              examId: this.responseBody[index].examId,
              usersId:4


            }




            this.studentExam.AddStudentExam(this.studExam).subscribe({
              next: (response) => {
                console.log("Add");

              }
            })

           }

          else {
                 console.log("fail");
                 }




        }

      // let x = this.CorrectAnswer[index];

      // if (x == this.responseBody[index].choices.find(x => x.isCorrect == true)?.answerText) {

      //   this.sum += this.responseBody[index].degree;

      // }


    }

    console.log(this.sum);

    }


  }





}
