import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ExamsComponent } from './exams.component';
import {angularMaterialModule} from "../angularMaterial.module";
import {ExamsRouteModule} from "./exams-route.module";

@NgModule({
  declarations: [
    ExamsComponent
  ],
  imports: [
    CommonModule,
    angularMaterialModule,
    ExamsRouteModule
  ]
})
export class ExamsModule { }
