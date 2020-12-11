import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RoomFormComponent } from './room-form/room-form/room-form.component';



@NgModule({
  declarations: [RoomFormComponent],
  imports: [
    CommonModule
  ],
  exports: [
    RoomFormComponent
  ]
})
export class SharedModule { }
