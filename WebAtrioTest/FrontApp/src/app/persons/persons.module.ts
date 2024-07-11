import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule, Routes } from '@angular/router';
import { PersonsComponent } from './persons.componenet';
import { FormComponent } from './form/form.component';
import { FormAddEmploiComponent } from './form-add-emploi/form-add-emploi.component';

const routes: Routes = [
  {
    path: "",
    data: {
      title: "Persons",
      urls: [{ title: "Persons", url: "/persons" }, { title: "Persons" }],
    },
    component: PersonsComponent,
  },
];

@NgModule({
  declarations: [
    PersonsComponent,
    FormComponent,
    FormAddEmploiComponent
  ],
  imports: [
    FormsModule,
    ReactiveFormsModule,
    CommonModule,
    RouterModule.forChild(routes),
  ],
 
})
export class PersonsModule { }
