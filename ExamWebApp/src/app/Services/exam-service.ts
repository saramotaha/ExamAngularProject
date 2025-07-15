import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IExam } from '../Interfaces/iexam';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ExamService {

  BaseUrl = "https://localhost:7198/api/Exam";
  // BaseUrl = "http://localhost:5026/api/Exam";


  constructor(private http: HttpClient) { }

  GetAllExams() {
    return this.http.get(this.BaseUrl);
  }


  GetExamsOfUser(id: number) {

   return this.http.get(`${this.BaseUrl}/${id}`)

  }


  DeleteExam(id:number):Observable<any> {
   return this.http.delete(`${this.BaseUrl}/${id}`);
  }


  AddExam(exam: IExam):Observable<any>{
   return this.http.post(`${this.BaseUrl}`, exam);
  }




}
