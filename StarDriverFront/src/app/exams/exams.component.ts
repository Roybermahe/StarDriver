import { Component, OnInit } from '@angular/core';
import {ExamsModule} from "./exams.module";
import {ExamModel} from "../../Model/Exam/exam-model";
import {MatDialog} from "@angular/material/dialog";
import {ExamFormComponent} from "../shared/exam-form/exam-form.component";

@Component({
  selector: 'app-exams',
  templateUrl: './exams.component.html',
  styleUrls: ['./exams.component.css']
})
export class ExamsComponent implements OnInit {

  public Exam = new ExamModel();
  constructor(public dialog: MatDialog) { }

  ngOnInit(): void {
  }

  openDialog() {
    const dialogRef = this.dialog.open(ExamFormComponent, {
      width: "700px"
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log(`Dialog result: ${result}`);
    });
  }

}
