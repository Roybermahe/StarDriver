import {AfterViewInit, Component, OnInit, Output, ViewChild} from '@angular/core';
import {ExamModel} from "../../Model/Exam/exam-model";
import { ExamService, ResponseExam} from "../../Services/Exam/exam.service";
import {MatDialog} from "@angular/material/dialog";
import {ExamFormComponent} from "../shared/exam-form/exam-form.component";
import {MatTableDataSource} from "@angular/material/table";
import {MatPaginator} from "@angular/material/paginator";
import {ActivatedRoute, Router} from "@angular/router";
import {RouterLink} from "@angular/router";

@Component({
  selector: 'app-exams',
  templateUrl: './exams.component.html',
  styleUrls: ['./exams.component.css']
})
export class ExamsComponent implements OnInit, AfterViewInit {
  displayedColumns: string[] = ['No', 'Título', 'Descripción', 'Realización', 'Terminación', 'Ver'];
  @ViewChild(MatPaginator) paginator: MatPaginator | undefined;
  public exam = new ExamModel();
  public response = new ResponseExam();
  public data: ExamModel[] = [];
  public dataSource = new MatTableDataSource<ExamModel>();

  constructor(
    public dialog: MatDialog,
    private examService: ExamService,
  ) {
  }

  ngOnInit(): void {
    this.onGet()
  }

  onGet(): void{
    this.examService.Get("Exam",).subscribe(Response=>{
      this.response = Response;
      this.data = <ExamModel[]>Response.examlist;
      this.dataSource = new MatTableDataSource(this.data);
      console.log(this.data);
    }, error => console.log(error));
  }


  ngAfterViewInit() {
    this.dataSource.paginator = <MatPaginator>this.paginator;
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

