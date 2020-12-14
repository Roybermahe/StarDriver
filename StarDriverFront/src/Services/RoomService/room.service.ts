import { Injectable } from '@angular/core';
import { RoomModel } from 'src/Model/Room/room-model';
import {HttpGenericService} from "../http-generic/http-generic.service";

@Injectable({
  providedIn: 'root'
})
export class RoomService extends HttpGenericService<RoomModel, responseRoom>{

}

export  class responseRoom {
  message?: string;
  room?: RoomModel;
  roomList?: RoomModel[];
}
