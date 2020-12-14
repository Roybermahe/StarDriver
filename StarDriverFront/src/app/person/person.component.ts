import {Component, OnInit, ViewChild} from '@angular/core';
import {MatDialog} from "@angular/material/dialog";
import {PersonFormComponent} from "../shared/person-form/person-form.component";
import {PersonModel} from "../../Model/Person/person-model";
import {PersonService, ResponsePerson} from "../../Services/PersonService/person.service";
import {MatSnackBar} from "@angular/material/snack-bar";
import {MatTableDataSource} from "@angular/material/table";
import {PersonFormUpdateComponent} from "../shared/person-form-update/person-form-update.component";


@Component({
  selector: 'app-person',
  templateUrl: './person.component.html',
  styleUrls: ['./person.component.css']
})
export class PersonComponent implements OnInit {

  response = new ResponsePerson();

  displayedColumns: string[] = ['No','Identificacion', 'Name', 'Surname', 'Phone', 'Mail', 'Direction', 'Ver'];
  columnsToDisplay: string[] = this.displayedColumns.slice();
  data: PersonModel[] = [];
  dataSource: MatTableDataSource<PersonModel>;


  constructor(public dialog: MatDialog, private personService: PersonService, private _snackBar: MatSnackBar) {
    this.dataSource = new MatTableDataSource(this.data);
  }


  ngOnInit(): void {
  this.onGet();
  }

  onGet(): void{

    this.personService.Get("Person",).subscribe(Response=>{
      this.response = Response;
      this.data = <PersonModel[]>Response.personlist;
      this.dataSource = new MatTableDataSource(this.data);
      console.log(this.data);
    }, error => console.log(error));

  }


  openDialog() {
    const dialogRef = this.dialog.open(PersonFormComponent, {
      width: '700px'
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log(`Dialog result: ${result}`);
    });
  }

  openDialogUpdate(element: PersonModel) {
    console.log(element);
    const dialogRef = this.dialog.open(PersonFormUpdateComponent, {
      width: '700px',
      data: element
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log(`Dialog result: ${result}`);
    });
  }


  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }
}
