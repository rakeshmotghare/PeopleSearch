import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IPeople } from './people.interface';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';

@Injectable({
    providedIn: 'root'
})
export class HomeService {
    private http: HttpClient;
    private baseUrl: string;

    constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this.baseUrl = baseUrl;
        this.http = http;
    }

    getPeople(): Observable<IPeople> {
        return this.http.get<IPeople>(this.baseUrl + 'People/Get')
            .pipe(
                retry(1),
                catchError(this.handleError))
    }

    searchByName(searchName): Observable<IPeople> {
        return this.http.get<IPeople>(this.baseUrl + 'People/People/' + searchName)
            .pipe(
                retry(1),
                catchError(this.handleError)
            )
    }

    // Error handling 
    handleError(error) {
        let errorMessage = '';
        if (error.error instanceof ErrorEvent) {
            // Get client-side error
            errorMessage = error.error.message;
        } else {
            // Get server-side error
            errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
        }
        console.log(errorMessage);
        return throwError(errorMessage);
    }
}
