import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ExamFormComponent } from './exam-form/exam-form.component';
import {angularMaterialModule} from "../angularMaterial.module";
import {FormsModule, ReactiveFormsModule} from "@angular/forms";

@NgModule({
  declarations: [ExamFormComponent],
  imports: [
    CommonModule, angularMaterialModule, ReactiveFormsModule, FormsModule
  ],
  exports: [
    ExamFormComponent
  ]
})
export class SharedModule { }
