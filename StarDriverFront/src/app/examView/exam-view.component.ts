import {Component, OnInit} from '@angular/core';
import { ExamService, ResponseExam} from "../../Services/Exam/exam.service";
import {ExamModel} from "../../Model/Exam/exam-model";
import {NgForm} from "@angular/forms";
import {MatSnackBar} from "@angular/material/snack-bar";
import {MatDialog} from "@angular/material/dialog";
import {ActivatedRoute, Router} from "@angular/router";
import {MatTableDataSource} from "@angular/material/table";


@Component({
  selector: 'app-exam-view',
  templateUrl: './exam-view.component.html',
  styleUrls: ['./exam-view.component.css']
})
export class ExamViewComponent implements OnInit {

  public IdExam = '';
  response = new ResponseExam();
  DateFinish: Date = new Date();
  DateStart: Date = new Date();
  data: ExamModel = new ExamModel();
  exam: ExamModel = new ExamModel();
  constructor(
    private activateRoute: ActivatedRoute,
    private router: Router,
    private examService: ExamService,
    private _snackBar: MatSnackBar
  ) { }

  ngOnInit(): void {
    this.IdExam = <string>this.activateRoute.snapshot.paramMap.get("IdExam");
    this.onGet(parseInt(this.IdExam));
  }

  onGet(id: number): void{
    this.examService.Get("Exam/GetExam?id="+id).subscribe(Response=>{
      this.response = Response;
      this.data = <ExamModel>Response.exam;
    }, error => console.log(error));
  }

  onSubmit(): string {

    if(!this.exam.onValid()) return "Hacen falta title y descripcion";
    this.examService.Put("Exam", this.exam).subscribe(Response => {
      this.response = Response;
      this._snackBar.open(<string>this.response.message, 'cerrar', {
        duration: 2000
      });
    }, error => console.log(error));
    return "Datos Acutualizados exitosamente";
  }

  onForm(f: NgForm) {
    this.exam.examId = +this.IdExam;
    this.exam.tittle = this.data.tittle;
    this.exam.description = this.data.description;
    this.exam.dateRealization = this.exam.formattedDate(this.DateStart.toDateString());
    this.exam.dateFinish = this.exam.formattedDate(this.DateFinish.toDateString());
    console.log(this.onSubmit());

  }

}
