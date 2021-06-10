import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { MessageService } from './message.service';
import { User } from './models';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient,private messageService: MessageService) {
  }

  login(email: string, password: string) {
    return this.http.post<User>('/api/login', { email, password })
      // this is just the HTTP call, 
      // we still need to handle the reception of the token
      .pipe(
        tap(),
        catchError(this.handleError<User>('login'))
      )
  }
  /**
   * Handle Http operation that failed.
   * Let the app continue.
   * @param operation - name of the operation that failed
   * @param result - optional value to return as the observable result
   */
  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead

      // TODO: better job of transforming error for user consumption
      this.log(`${operation} failed: ${error.message}`);

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }

  /** Log a AuthorService message with the MessageService */
  private log(message: string) {
    this.messageService.add(`AuthorService: ${message}`);
  }
}