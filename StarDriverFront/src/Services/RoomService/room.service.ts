import { Injectable } from '@angular/core';
import { RoomModel } from 'src/Model/Room/room-model';
import {HttpGenericService} from "../http-generic/http-generic.service";

@Injectable({
  providedIn: 'root'
})
export class RoomService extends HttpGenericService<RoomModel, responseRoom>{

}

export  class responseRoom {
  Message?: string;
  Room?: RoomModel;
  Roomlist?: RoomModel[];
}
