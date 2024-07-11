import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from '../../environments/environment'
 
import { catchError } from 'rxjs/operators';
import { Emploi } from '../Models/emploi.ts';
@Injectable({
    providedIn: 'root'
  })

  export class EmploiService {
  
    private apiUrl = environment.apiUrl; // Use the API URL from the environment configuration
  
    constructor(private http: HttpClient) { }

    //Permettent d'ajouter un emploi à une personne avec une date de début et de fin d'emploi.
     //Pour le poste actuellement occupé, la date de fin n'est pas obligatoire.
     //Une personne peut avoir plusieurs emplois aux dates qui se chevauchent.


     //Renvoient tous les emplois d'une personne entre deux plages de dates
     GetEmploisOfPersonByDate(idPerson: number,dateDebut:Date,dateFin : Date): Observable<Emploi[]> {
      const headers = new HttpHeaders()
      .set('idPersonne', idPerson.toString())
      .set('dateDebut', dateDebut.toISOString())
      .set('dateFin', dateFin.toISOString());
      
      return this.http.get<Emploi[]>(`${this.apiUrl}/api/Emploi/GetEmploisByDate`,{ headers })
        .pipe(
          catchError(this.handleError) 
        );
    }



         private handleError(error: any): Observable<never> {
            console.error('An error occurred:', error);
            return throwError('Something went wrong');
        }
        
      }
      