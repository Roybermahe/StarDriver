import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {ClassRoomDetailComponent} from "./class-room-detail/class-room-detail.component";


const routes: Routes = [
  { path: "", component: ClassRoomDetailComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ClassRoomDetailRouteModule { }
