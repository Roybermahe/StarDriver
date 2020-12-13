import { Component, OnInit } from '@angular/core';
import {ExamService, ResponseExam } from "../../../Services/Exam/exam.service";
import {ExamModel} from "../../../Model/Exam/exam-model";
import { FormControl, FormGroup, NgForm} from "@angular/forms";
import {MatSnackBar, MatSnackBarConfig} from "@angular/material/snack-bar";

@Component({
  selector: 'app-exam-form',
  templateUrl: './exam-form.component.html',
  styleUrls: ['./exam-form.component.css']
})
export class ExamFormComponent implements OnInit {

  response = new ResponseExam();
  exam = new ExamModel();
  DateFinish: string = "";
  DateStart: string = "";
  constructor(
    private examService: ExamService,
    private _snackBar: MatSnackBar
  ) { }

  ngOnInit(): void {
  }

  onSubmit(): string {
    if(!this.exam.onValid()) return "Hacen falta title y descripcion";

    this.examService.Post("Exam", this.exam).subscribe(Response => {
      this.response = Response;
      if(this.response.Message) {
        this._snackBar.open(this.response.Message);
      }
    }, error => console.log(error));

    return "Datos guardados exitosamente";
  }

  onForm(f: NgForm) {
    this.exam.DateRealization = this.exam.formattedDate(this.DateStart);
    this.exam.DateFinish = this.exam.formattedDate(this.DateFinish);
    console.log(this.onSubmit());
  }
}
