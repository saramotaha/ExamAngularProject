import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Ilogin } from '../Interfaces/ilogin';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  LoginUrl: string = "http://localhost:5026/api/Auth/login";

  constructor(private http: HttpClient) { }



  loginToDashBoard(LoginData:Ilogin):Observable<any>{

    return this.http.post(`${this.LoginUrl}` , LoginData);
  }

}
