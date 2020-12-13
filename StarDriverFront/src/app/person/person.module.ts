import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PersonComponent } from './person.component';
import {PersonRouteModule} from "./person-route.module";
import {SharedModule} from "../shared/shared.module";
import {angularMaterialModule} from "../angularMaterial.module";



@NgModule({
  declarations: [PersonComponent],
  imports: [
    CommonModule,
    PersonRouteModule,
    SharedModule,
    angularMaterialModule
  ]
})
export class PersonModule { }
