import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ClassRoomComponent } from './class-room.component';
import {ClassRoomRouteModule} from "./class-room-route.module";

@NgModule({
  declarations: [ClassRoomComponent],
  imports: [
    CommonModule,
    ClassRoomRouteModule
  ]
})
export class ClassRoomModule { }
