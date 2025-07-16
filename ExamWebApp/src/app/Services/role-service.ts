import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RoleService {

  roleUrl: string = 'http://localhost:5026/api/Auth/check-role';
  constructor(private http: HttpClient) { }

  getRole(): Observable<any> {
    const key = localStorage.getItem("token");
    const header = new HttpHeaders({

      Authorization: `Bearer ${key}`

    });

    return this.http.get<any>(this.roleUrl,{ headers: header})
  }


}
