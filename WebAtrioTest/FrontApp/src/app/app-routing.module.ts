import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { FullComponent } from './layouts/full/full.component';

export const Approutes: Routes = [
  {
    path: '',
    component: FullComponent,
    children: [
      
      {
        path: 'persons',
        loadChildren: () => import('./persons/persons.module').then(m => m.PersonsModule)
      },
      {
        path: 'works',
        loadChildren: () => import('./persons/persons.module').then(m => m.PersonsModule)
      }
    ]
  },
  {
    path: '**',
    redirectTo: '/starter'
  }
];
