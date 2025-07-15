import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ShowStudentScores {

  constructor(private http: HttpClient) { }
  BaseUrl:string  = 'http://localhost:5026/api/StudentExam/AllResults';

  GetAllStudentsScores():Observable<any> {
   return  this.http.get(`${this.BaseUrl}`)
  }


  GetStudentScoresById(id: number) :Observable<any>{
    return this.http.get(`http://localhost:5026/api/StudentExam/${id}`);

  }
}
