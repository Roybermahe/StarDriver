import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PersonFormComponent } from './person-form/person-form.component';
import {angularMaterialModule} from "../angularMaterial.module";
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import { PersonFormUpdateComponent } from './person-form-update/person-form-update.component';
import {RoomFormComponent} from "./room-form/room-form/room-form.component";
import { ExamFormComponent } from './exam-form/exam-form.component';

@NgModule({
  declarations: [PersonFormComponent, PersonFormUpdateComponent, RoomFormComponent],
  imports: [
    CommonModule, angularMaterialModule, ReactiveFormsModule, FormsModule
  ],
  exports: [
   PersonFormComponent, PersonFormUpdateComponent, RoomFormComponent, ExamFormComponent
  ]
})
export class SharedModule { }


    