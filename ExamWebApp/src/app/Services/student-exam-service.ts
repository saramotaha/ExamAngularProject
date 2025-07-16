import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IStudentExam } from '../Interfaces/istudent-exam';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class StudentExamService {

  constructor(private http: HttpClient) { }

  BaseUrl: string = 'http://localhost:5026/api/StudentExam';


  AddStudentExam(student: IStudentExam): Observable<any> {
    const token = localStorage.getItem('token');

  const headers = new HttpHeaders({
    'Authorization': `Bearer ${token}`
  });

  return this.http.post(`${this.BaseUrl}`, student, { headers });

  //  return this.http.post(`${this.BaseUrl}`, student,{ headers });

  }

}
