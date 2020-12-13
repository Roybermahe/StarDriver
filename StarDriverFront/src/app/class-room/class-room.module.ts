import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ClassRoomComponent } from './class-room.component';
import {ClassRoomRouteModule} from "./class-room-route.module";
import {SharedModule} from "../shared/shared.module";
import {angularMaterialModule} from "../angularMaterial.module";

@NgModule({
  declarations: [ClassRoomComponent],
  imports: [
    CommonModule,
    ClassRoomRouteModule,
    SharedModule,
    angularMaterialModule
  ]
})
export class ClassRoomModule { }
