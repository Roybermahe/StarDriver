import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ExamsComponent } from './exams.component';
import {ExamsRouteModule} from "./exams-route.module";
import {SharedModule} from "../shared/shared.module";
import {angularMaterialModule} from "../angularMaterial.module";

@NgModule({
  declarations: [
    ExamsComponent
  ],
  imports: [
    CommonModule,
    ExamsRouteModule,
    SharedModule,
    angularMaterialModule
  ]
})
export class ExamsModule { }
