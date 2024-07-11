import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from '../../environments/environment'
import { Person } from '../Models/person.ts'; 
import { catchError } from 'rxjs/operators';
@Injectable({
    providedIn: 'root'
  })
  export class PersonsService {
  
    private apiUrl = environment.apiUrl; 
  
    constructor(private http: HttpClient) { }

        getPersonsList(): Observable<Person[]> {
            return this.http.get<Person[]>(`${this.apiUrl}/api/Personne/GetListPersons`)
              .pipe(
                catchError(this.handleError) 
              );
              
          }

          addPerson(person: any): Observable<any> { 
            return this.http.post<any>(`${this.apiUrl}/api/Personne/AddPerson`, person)
              .pipe(
                catchError(this.handleError)
              );
          }


        
    //Renvoient toutes les personnes ayant travaillé pour une entreprise donnée.
    GetPersonsByCompany(companyName: any): Observable<any> { 
      return this.http.post<any>(`${this.apiUrl}/api/Personne/GetListPersonsByWork`, companyName)
        .pipe(
          catchError(this.handleError)
        );
    }
         private handleError(error: any): Observable<never> {
            console.error('An error occurred:', error);
            return throwError('Something went wrong');
        }
        
      }
      