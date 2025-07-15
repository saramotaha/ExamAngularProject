import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IRegister } from '../Interfaces/iregister';
import { catchError, Observable, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RegisterService {
  private readonly baseUrl = "https://localhost:7198/api/Auth/register";

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
      // Client-side error
      errorMessage = `Error: ${error.error.message}`;
    } else {
      // Server-side error
      if (error.status === 400) {
        // Handle validation errors from ASP.NET
        if (error.error.errors) {
          errorMessage = error.error.errors.map((err: any) => err.description).join(', ');
        } else {
          errorMessage = error.error.message || 'Invalid request data';
        }
      } else if (error.status === 500) {
        errorMessage = 'Server error occurred. Please try again later.';
      }
    }
    
    return throwError(() => new Error(errorMessage));
  }
}
