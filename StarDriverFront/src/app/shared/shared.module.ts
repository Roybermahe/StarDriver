import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RoomFormComponent } from './room-form/room-form/room-form.component';
import { angularMaterialModule} from "../angularMaterial.module";
import {FormsModule, ReactiveFormsModule} from "@angular/forms";


@NgModule({
  declarations: [RoomFormComponent],
  imports: [
    CommonModule,
    angularMaterialModule,
    ReactiveFormsModule,
    FormsModule

  ],
  exports: [
    RoomFormComponent
  ]
})
export class SharedModule { }
