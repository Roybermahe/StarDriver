import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {ExamViewComponent} from "./exam-view.component";

const routes: Routes = [
  { path: "", component: ExamViewComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ExamViewRouteModule { }
