import { Component, OnInit, } from '@angular/core';
import { PersonsService } from './PersonsService';
import { Person } from '../Models/person.ts';

@Component({
  templateUrl: './persons.component.html'
})
export class PersonsComponent implements OnInit {

  persons: Person[] = [];
  showDeleteModal : boolean = false;
  showForm: boolean = false;
  showFormForAddEmploi: boolean = false;
  personneList: boolean = true;
  constructor(private personsService: PersonsService) {
  }

  ngOnInit(): void {
    this.GetPersons();
  }
  GetPersons() {
    this.personsService.getPersonsList().subscribe(
      
      (data: any) => {
        this.persons = data.persons;
      },
      (error) => {
        console.error('Erreur lors de la récupération des personnes:', error);
      }
    );
  }

  navigateToAddPersonForm(){
    this.showForm = true;
  }


  addEmploi(idPerson : number,nom:string,prenom:string){
    this.navigateToAddEmploi();
  }

  navigateToAddEmploi(){

    this.personneList=false;
    this.showFormForAddEmploi = true;

  }
  editPerson(idPerson : number){

  }

  deletePerson(idPerson : number){
    this.showDeleteModal = true;
  }


  GetPersoneByCompany(companyName: string){
    this.personsService.GetPersonsByCompany(companyName);
  }
}

