import {AfterViewInit, Component, OnInit, ViewChild} from '@angular/core';
import {MatDialog} from "@angular/material/dialog";
import {RoomFormComponent} from "../shared/room-form/room-form/room-form.component";
import {MatTableDataSource} from "@angular/material/table";
import {RoomModel} from "../../Model/Room/room-model";
import {RoomService} from "../../Services/RoomService/room.service";
import {MatPaginator} from "@angular/material/paginator";
import {InstructorModel} from "../../Model/Instructor/instructor-model";
import {DevPlanModel} from "../../Model/DevPlan/dev-plan-model";
import {InstructorService} from "../../Services/IntructorService/instructor.service";
import {DevPlanService} from "../../Services/DevPlan/dev-plan.service";
import {HttpGenericService} from "../../Services/http-generic/http-generic.service";

@Component({
  selector: 'app-class-room',
  templateUrl: './class-room.component.html',
  styleUrls: ['./class-room.component.css']
})
export class ClassRoomComponent implements OnInit {
  roomlist: RoomModel[]= [];
  displayedColumns: string[] = ['No', 'Sala', 'Ver Sala'];
  dataSource = new MatTableDataSource<RoomModel>();
  @ViewChild(MatPaginator) paginator: MatPaginator | undefined;
  constructor(
    private instructorService: InstructorService,
    private devPlanService: DevPlanService,
    private roomService: RoomService,
    public dialog: MatDialog) { }

   ngOnInit() {
    this.onGet();
  }

  onGet() {
   Promise.all([
      this.roomService.Get("Room").subscribe(Response => {
        this.roomlist = <RoomModel[]>Response.roomList;
        this.dataSource = new MatTableDataSource<RoomModel>(this.roomlist);
        this.dataSource.paginator = <MatPaginator>this.paginator;
      })
    ]);
  }

  openDialog() {
    const dialogRef = this.dialog.open(RoomFormComponent, {
      width: "700px"
    });
    this.onGet();
  }


}

