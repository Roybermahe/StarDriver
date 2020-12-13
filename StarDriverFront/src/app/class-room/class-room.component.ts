import { Component, OnInit } from '@angular/core';
import {MatDialog} from "@angular/material/dialog";
import {RoomFormComponent} from "../shared/room-form/room-form/room-form.component";

@Component({
  selector: 'app-class-room',
  templateUrl: './class-room.component.html',
  styleUrls: ['./class-room.component.css']
})
export class ClassRoomComponent implements OnInit {

  constructor(public dialog: MatDialog) { }

  ngOnInit(): void {
  }

  openDialog() {
    const dialogRef = this.dialog.open(RoomFormComponent, {
      width: "700px"
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log(`Dialog result: ${result}`);
    });
  }
}
