import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IRegister } from '../Interfaces/iregister';
import { catchError, Observable, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RegisterService {
  private readonly baseUrl = "http://localhost:5026/api/Auth/register";

  constructor(private http: HttpClient) { }

  registerUser(user: IRegister): Observable<{
    success: boolean;
    message: string;
    user?: {
      Id: number;
      Name: string;
      Email: string;
      role: string;
    }
  }> {
    return this.http.post<{
      success: boolean;
      message: string;
      user?: {
        Id: number;
        Name: string;
        Email: string;
        role: string;
      }
    }>(this.baseUrl, user).pipe(
      catchError(this.handleError)
    );
  }

  private handleError(error: HttpErrorResponse) {
    let errorMessage = 'An unknown error occurred!';

    if (error.error instanceof ErrorEvent) {
      // Client-side error (e.g., network issue)
      errorMessage = `Client error: ${error.error.message}`;
    } else {
      // Server-side error
      switch (error.status) {
        case 400:
          // Handle ASP.NET validation errors
          if (error.error.errors) {
            const validationErrors = error.error.errors;
            errorMessage = Object.keys(validationErrors)
              .map(key => `${key}: ${validationErrors[key].join(', ')}`)
              .join(' | ');
          }
          else if (error.error.message) {
            errorMessage = error.error.message;
          } else {
            errorMessage = 'Bad request. Please check your input.';
          }
          break;

        case 500:
          errorMessage = 'Server error. Please try again later.';
          break;

        default:
          errorMessage = `HTTP Error: ${error.status} - ${error.statusText}`;
      }
    }

    return throwError(() => new Error(errorMessage));

  }
  
  return throwError(() => new Error(errorMessage));
}


}
