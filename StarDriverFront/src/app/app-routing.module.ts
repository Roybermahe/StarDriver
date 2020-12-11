import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  { path: "", redirectTo: "index", pathMatch: "full"},
  { path: "index", loadChildren: () => import("./class-room/class-room.module").then(m => m.ClassRoomModule) }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
