import { Component, OnInit } from '@angular/core';
import {ExamService, ResponseExam } from "../../../Services/Exam/exam.service";
import {ExamModel} from "../../../Model/Exam/exam-model";

@Component({
  selector: 'app-exam-form',
  templateUrl: './exam-form.component.html',
  styleUrls: ['./exam-form.component.css']
})
export class ExamFormComponent implements OnInit {

  response = new ResponseExam();
  exam = new ExamModel();
  constructor(
    private examService: ExamService
  ) { }

  ngOnInit(): void {
  }

  onSubmit(): string {
    if(!this.exam.onValid()) return "Hacen falta title y descripcion";

    this.examService.Post("Exam", this.exam).subscribe(Response => {
      this.response = Response;
    }, error => console.log(error));

    return "Datos guardados exitosamente";
  }
}
