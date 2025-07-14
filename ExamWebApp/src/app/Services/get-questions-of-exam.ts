import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class GetQuestionsOfExam {

  constructor(private http: HttpClient) { }

  BaseUrl: string = 'http://localhost:5026/api/Question/exam';

  GetQuestionsByExamId(ExamId:number):Observable<any> {
     return this.http.get(`${this.BaseUrl}/${ExamId}`);
  }

}
