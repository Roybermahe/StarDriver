import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ClassRoomDetailComponent } from './class-room-detail/class-room-detail.component';
import {ClassRoomDetailRouteModule} from "./class-room-detail-route.module";
import {angularMaterialModule} from "../angularMaterial.module";
import {SharedModule} from "../shared/shared.module";



@NgModule({
  declarations: [ClassRoomDetailComponent],
  imports: [
    CommonModule, ClassRoomDetailRouteModule, angularMaterialModule, SharedModule
  ]
})
export class ClassRoomDetailModule { }
