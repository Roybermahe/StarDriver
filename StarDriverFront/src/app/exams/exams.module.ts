import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ExamsComponent } from './exams.component';
import {ExamsRouteModule} from "./exams-route.module";

@NgModule({
  declarations: [
    ExamsComponent
  ],
  imports: [
    CommonModule,
    ExamsRouteModule
  ]
})
export class ExamsModule { }
