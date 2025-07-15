import { Component, OnInit } from '@angular/core';
import { ShowStudentScores } from '../../Services/show-student-scores';
import { IStudentScore } from '../../Interfaces/istudent-score';

@Component({
  selector: 'app-students-scores',
  imports: [],
  templateUrl: './students-scores.html',
  styleUrl: './students-scores.css'
})
export class StudentsScores implements OnInit {

  AllScores!: IStudentScore[];
  userName!: string;

  getUserDataFromToken() {
  const token = localStorage.getItem('token');

  if (!token) return null;

  const payload = token.split('.')[1];
  const decodedPayload = atob(payload);

  return JSON.parse(decodedPayload);
  }







  constructor(private scores: ShowStudentScores) { }


  ngOnInit(): void {

    this.scores.GetAllStudentsScores().subscribe({
      next: (response) => {

        this.AllScores = response;
        console.log(this.AllScores);
        let user = this.getUserDataFromToken();
        this.userName = user["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"];;
        console.log(this.userName);


      }
    })



  }




}
