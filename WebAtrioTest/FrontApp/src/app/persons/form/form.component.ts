import { Component, EventEmitter, Output } from '@angular/core';
import { Person } from '../../Models/person.ts';
import { PersonsService } from '../PersonsService';

@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.scss']
})
export class FormComponent {
  @Output() closeFormEvent = new EventEmitter<void>();
 person : Person = new Person(0,'','',new Date(),'',0);
  constructor(private personsService: PersonsService) {
    
    
  }

  addPerson(){
    if (this.person.nom && this.person.prenom && this.person.dateDeNaissance) {
    const dateNaissance = new Date(this.person.dateDeNaissance);
    const age = this.calculateAge(dateNaissance);

    if (age >= 150) {
      alert('L\'âge de la personne ne peut pas dépasser 150 ans.');
      return; 
     }
     else {
      this.personsService.getPersonsList
     }

     
    } else {
      
      alert('Veuillez remplir tous les champs.');
    }


  }
  

  calculateAge(birthday: Date) {
    const ageDiff = Date.now() - birthday.getTime();
    const ageDate = new Date(ageDiff); 
    return Math.abs(ageDate.getUTCFullYear() - 1970);
  }
}
