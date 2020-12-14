import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

  { path: "", redirectTo: "/index", pathMatch: "full"},
  { path: "index", loadChildren: () => import("./person/person.module").then(m => m.PersonModule) },
  { path: "room", loadChildren: () => import("./class-room/class-room.module").then(m => m.ClassRoomModule) },
  { path: "room/:Id", loadChildren: () => import("./class-room-detail/class-room-detail.module").then(m => m.ClassRoomDetailModule)}
  { path: "verExamen/:IdExam", loadChildren: () => import("./examView/exam-view.module").then(m => m.ExamViewModule) }
  { path: "exam", loadChildren: () => import("./exams/exams.module").then(m => m.ExamsModule) },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
