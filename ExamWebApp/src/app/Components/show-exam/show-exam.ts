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

import { ExamService } from '../../Services/exam-service';
import { IExam } from '../../Interfaces/iexam';


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


  constructor(private http: HttpClient, private questions: GetQuestionsOfExam , private route:ActivatedRoute  , private studentExam:StudentExamService , private examById:ExamService) { }

  user!: any;

  ExamID!: number;

  Exam!: IExam;

  SubmitExamForm!: FormGroup;
  sum: number = 0;

  studExam!: IStudentExam;

  options!:[];


  ngOnInit(): void {
  this.ExamID = +this.route.snapshot.paramMap.get('id')!;

  this.questions.GetQuestionsByExamId(this.ExamID).subscribe({
    next: (response) => {
      this.responseBody = response;
      this.CorrectAnswer = new Array(this.responseBody.length).fill('');

      // this.responseBody = response;
      //   console.log(response);
      //   this.CorrectAnswer = new Array(this.responseBody.length).fill('');

        this.choices = response.choices
    },
    error: (err) => {
      console.error("❌ Error loading questions:", err);
    }
  });





}



  getUserDataFromToken() {
  const token = localStorage.getItem('token');

  if (!token) return null;

  const payload = token.split('.')[1];
  const decodedPayload = atob(payload);

  return JSON.parse(decodedPayload);
}



        // this.responseBody = response;
        // console.log(response);
        // this.CorrectAnswer = new Array(this.responseBody.length).fill('');

        // this.choices = response.choices

      // }
    // });







  //    this.SubmitExamForm = new FormGroup({

  //   text: new FormControl(`${this.responseBody[0].text} `),
  //   degree: new FormControl(`${this.responseBody[0].degree}`),
  //   optionA: new FormControl(``),
  //   optionB: new FormControl(``),
  //   optionC: new FormControl(''),




  // })




  // }






 SubmitExam() {
   this.user = this.getUserDataFromToken();
      console.log(this.user['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier']);
      console.log(this.user);

  if (!this.user || !this.responseBody || this.responseBody.length === 0) return;

  console.log("User Answers:", this.CorrectAnswer);

  this.sum = 0;

  for (let i = 0; i < this.responseBody.length; i++) {
    const question = this.responseBody[i];
    const correctAnswer = question.choices.find(c => c.isCorrect)?.answerText;
    const selected = this.CorrectAnswer[i];

    if (selected === correctAnswer) {
      this.sum += question.degree;
      console.log(`Question ${i + 1}: ✅ Correct`);
    } else {
      console.log(`Question ${i + 1}: ❌ Wrong`);
    }
  }

   console.log("Total Score:", this.sum);


   this.examById.GetExamsOfUser(this.ExamID).subscribe({
     next:(exam:IExam) => {
      const studentExam: IStudentExam = {
        score: this.sum,
        examId: this.ExamID,
        usersId: this.user['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier'],
        exam: {
          name: exam.name,
          description: exam.description,
          duration: exam.duration,
          totalScore: exam.totalScore
        }
      };

      this.studentExam.AddStudentExam(studentExam).subscribe({
        next: () => {
          console.log(exam);

          console.log("✅ Exam Submitted Successfully!");
          alert("Exam Submitted Successfully!");
        },
        error: (err) => {
          console.error("❌ Error submitting exam:", err);
        }
      });
    },
    error: (err) => {
      console.error("❌ Error loading exam details:", err);
    }
  });
}










}
