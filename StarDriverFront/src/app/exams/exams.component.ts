import { Component, OnInit } from '@angular/core';
import {ExamsModule} from "./exams.module";
import {ExamModel} from "../../Model/Exam/exam-model";

@Component({
  selector: 'app-exams',
  templateUrl: './exams.component.html',
  styleUrls: ['./exams.component.css']
})
export class ExamsComponent implements OnInit {

  public Exam = new ExamModel();
  constructor() { }

  ngOnInit(): void {
  }

  onSubmit() {

  }

}
