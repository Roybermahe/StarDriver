import { Component, OnInit } from '@angular/core';
import {ResponseRoom, RoomService} from "../../../../Services/RoomService/room.service";
import {RoomModel} from "../../../../Model/Room/room-model";

@Component({
  selector: 'app-room-form',
  templateUrl: './room-form.component.html',
  styleUrls: ['./room-form.component.css']
})
export class RoomFormComponent implements OnInit {

  response = new ResponseRoom();
  room = new RoomModel();

  constructor(
    private roomservice: RoomService
  ) { }

  ngOnInit(): void {
  }

  onSubmit(){
    if(!this.room.onValid())  return "Hace falta un titulo";

    this.roomservice.Post("Room", this.room).subscribe(Response =>{
      this.response = Response;
    }, error => console.log(error));

    return "Datos guardados exitosamente";
  }
}
