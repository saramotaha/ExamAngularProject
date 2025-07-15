import { Component, OnInit } from '@angular/core';
import { ShowStudentScores } from '../../Services/show-student-scores';
import { IStudentScore } from '../../Interfaces/istudent-score';

@Component({
  selector: 'app-student-score-in-his-exam',
  imports: [],
  templateUrl: './student-score-in-his-exam.html',
  styleUrl: './student-score-in-his-exam.css'
})
export class StudentScoreInHisExam  implements OnInit{

  constructor(private studentScore: ShowStudentScores) { }
  UserName!: string;

  getUserDataFromToken() {
  const token = localStorage.getItem('token');

  if (!token) return null;

  const payload = token.split('.')[1];
  const decodedPayload = atob(payload);

  return JSON.parse(decodedPayload);
  }

  AllResult!:IStudentScore [];

  ngOnInit(): void {

    var user = this.getUserDataFromToken();

    console.log(user);


    this.UserName = user['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name'];



    this.studentScore.GetStudentScoresById(user['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier']).subscribe(
      {
        next: (response) => {

          this.AllResult = response;

         }
       }
     )
  }


}
