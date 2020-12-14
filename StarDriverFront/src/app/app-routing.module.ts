import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  { path: "", redirectTo: "index", pathMatch: "full"},
  { path: "index", loadChildren: () => import("./exams/exams.module").then(m => m.ExamsModule) },
  { path: "verExamen/:IdExam", loadChildren: () => import("./examView/exam-view.module").then(m => m.ExamViewModule) }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
