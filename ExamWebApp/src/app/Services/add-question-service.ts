import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IQuestion } from '../Interfaces/iquestion';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AddQuestionService {

  BaseUrl: string = 'http://localhost:5026/api/Question';
  constructor(private http: HttpClient) { }

  AddQuestions(question: IQuestion): Observable<any> {
    return this.http.post(`${this.BaseUrl}`, question);
  }

}
