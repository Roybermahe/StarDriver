import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PersonFormComponent } from './person-form/person-form.component';



@NgModule({
  declarations: [PersonFormComponent],
  imports: [
    CommonModule
  ]
})
export class SharedModule { }
