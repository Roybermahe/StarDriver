import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ExamViewComponent } from './exam-view.component';
import {ExamViewRouteModule} from "./exam-view-route.module";
import {SharedModule} from "../shared/shared.module";
import {angularMaterialModule} from "../angularMaterial.module";
import {FormsModule, ReactiveFormsModule} from "@angular/forms";



@NgModule({
  declarations: [
    ExamViewComponent
  ],
  imports: [
    CommonModule,
    ExamViewRouteModule,
    SharedModule,
    angularMaterialModule,
    ReactiveFormsModule,
    FormsModule
  ]
})
export class ExamViewModule { }
