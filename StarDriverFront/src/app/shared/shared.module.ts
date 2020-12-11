import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ExamFormComponent } from './exam-form/exam-form.component';

@NgModule({
  declarations: [ExamFormComponent],
  imports: [
    CommonModule
  ],
  exports: [
    ExamFormComponent
  ]
})
export class SharedModule { }
