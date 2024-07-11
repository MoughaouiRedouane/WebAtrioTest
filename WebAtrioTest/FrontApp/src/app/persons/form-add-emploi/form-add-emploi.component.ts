import { Component } from '@angular/core';
import { EmploiService } from '../EmploiService';

@Component({
  selector: 'app-form-add-emploi',
  templateUrl: './form-add-emploi.component.html',
  styleUrls: ['./form-add-emploi.component.scss']
})
export class FormAddEmploiComponent {
  selectedPersonId:number=0;
  dateFin:Date = new Date();
  dateDebut:Date = new Date();
  posteActuellementOccupe : string ='';
  posteOccupe: string ='';
  constructor(private emploiService: EmploiService) {
  }
  areFieldsValid(): boolean {
    return (
      this.selectedPersonId !== 0 &&
      !!this.dateDebut &&
      !!this.posteActuellementOccupe &&
      !!this.posteOccupe
    );
  }
 
}
