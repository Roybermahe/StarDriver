import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  { path: "", redirectTo: "index", pathMatch: "full"},
  { path: "index", loadChildren: () => import("./exams/exams.module").then(m => m.ExamsModule) }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
