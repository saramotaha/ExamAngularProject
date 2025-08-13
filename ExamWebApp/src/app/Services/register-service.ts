import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IRegister } from '../Interfaces/iregister';
import { catchError, Observable, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RegisterService {

  RegisterData!: IRegister;

  baseUrl: string = "http://localhost:5026/api/Auth/register";

  constructor(private http: HttpClient) { }


    // return throwError(() => new Error(errorMessage));

  // }

//   return throwError(() => new Error(errorMessage));
// }


}
