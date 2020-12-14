import {AfterViewInit, Component, OnInit, ViewChild} from '@angular/core';
import {ActivatedRoute, Router, Routes} from "@angular/router";
import {RoomService} from "../../../Services/RoomService/room.service";
import {RoomModel} from "../../../Model/Room/room-model";
import {MatTableDataSource} from "@angular/material/table";
import {MatPaginator} from "@angular/material/paginator";
import {ApprenticeService} from "../../../Services/apprenticeService/apprentice.service";
import {ApprenticeModel} from "../../../Model/Apprentice/apprentice-model";
import {HttpGenericService} from "../../../Services/http-generic/http-generic.service";
import {MatSnackBar} from "@angular/material/snack-bar";

@Component({
  selector: 'app-class-room-detail',
  templateUrl: './class-room-detail.component.html',
  styleUrls: ['./class-room-detail.component.css']
})
export class ClassRoomDetailComponent implements OnInit {

  IdRoom: string = "";
  displayedColumns: string[] = ['No', 'Name', 'Surname', 'Mail', 'Direction', 'Phone', 'Add'];
  displayedColumnsApprentice: string[] = ['No', 'Name', 'Surname', 'Remove'];
  dataSource = new MatTableDataSource<ApprenticeModel>();
  dataSourceApprentice= new MatTableDataSource<ApprenticeModel>();
  @ViewChild(MatPaginator) paginator: MatPaginator | undefined;
  room: RoomModel = new RoomModel();
  constructor(
    private roomService: RoomService,
    private apprenticeService: ApprenticeService,
    private checkinService: HttpGenericService<checking, responsechecking>,
    private activateRoute: ActivatedRoute,
    private route: Router,
    private _snackBar: MatSnackBar
  ) { }

  ngOnInit(): void {
    this.IdRoom = <string>this.activateRoute.snapshot.paramMap.get("Id");
    this.onGet()
  }

  onGet() {
    this.roomService.Get("Room/GetRoom?id="+this.IdRoom).subscribe(Response => {
      this.room = <RoomModel>Response.room;
      let dataApprentice = <ApprenticeModel[]>Response.room?._apprentice;
      this.dataSourceApprentice = new MatTableDataSource<ApprenticeModel>(dataApprentice);
      this.dataSourceApprentice.paginator = <MatPaginator>this.paginator;
    }, error => this.route.navigateByUrl("index"));
    this.apprenticeService.Get("Person/Apprentices").subscribe(Response => {
      this.dataSource = new MatTableDataSource<ApprenticeModel>(<ApprenticeModel[]>Response.personlist);
      this.dataSource.paginator = <MatPaginator>this.paginator;
    });
  }

  chekApprentice(id: number) {
    this.checkinService.Post("Room/Apprentices", { idRoom: +this.IdRoom, idApprentice: id}).subscribe(Response =>{
      if(Response.message){
        this._snackBar.open(Response.message, 'cerrar', {
          duration: 2000
        });
      }
    }, error => console.log(error));
    this.onGet();
  }

  removeApprentice(id: number) {
    this.checkinService.Post("Room/RemoveApprentices", { idRoom: +this.IdRoom, idApprentice: id}).subscribe(Response =>{
      if(Response.message){
        this._snackBar.open(Response.message, 'cerrar', {
          duration: 2000
        });
      }
    }, error => console.log(error));
    this.onGet();
  }
}


export interface checking {
  idRoom?: number;
  idApprentice?: number;
}

export interface responsechecking {
  message?: string;
}
