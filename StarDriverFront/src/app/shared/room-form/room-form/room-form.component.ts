import { Component, OnInit } from '@angular/core';
import {ResponseRoom, RoomService} from "../../../../Services/RoomService/room.service";
import {RoomModel} from "../../../../Model/Room/room-model";
import {NgForm} from "@angular/forms";
import {MatSnackBar, MatSnackBarConfig} from "@angular/material/snack-bar";

@Component({
  selector: 'app-room-form',
  templateUrl: './room-form.component.html',
  styleUrls: ['./room-form.component.css']
})
export class RoomFormComponent implements OnInit {

  response = new ResponseRoom();
  room = new RoomModel();

  constructor(
    private roomservice: RoomService,
    private _snackBar: MatSnackBar
  ) { }

  ngOnInit(): void {
  }

  onSubmit(){
    if(!this.room.onValid())  return "Hace falta un titulo";

    this.roomservice.Post("Room", this.room).subscribe(Response =>{
      this.response = Response;
      if(this.response.Message){
        this._snackBar.open(this.response.Message);
      }
    }, error => console.log(error));

    return "Datos guardados exitosamente";
  }

  onForm(f: NgForm) {
    console.log(f.value);
  }
}
