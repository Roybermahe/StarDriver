import {states} from "../../Types/TypeRoom";
import {InstructorModel} from "../Instructor/instructor-model";
import {ApprenticeModel} from "../Apprentice/apprentice-model";

export class RoomModel {
  roomId?: number;
  name?: string;
  description?: string;
  state?: states;
  idInsturctor?: number;
  idDevPlan?: number;
  instructor?: InstructorModel;
  _apprentice?: ApprenticeModel[];

  constructor(RoomId?: number, Name?: string, Description?: string, IdInstructor?: number, IdDevPlan?: number) {
    this.roomId = RoomId;
    this.name = Name;
    this.description = Description;
    this.state = 'creado';
    this.idInsturctor = IdInstructor;
    this.idDevPlan = IdDevPlan;
  }

  onValid() {
    if(this.name){
      return this.name?.length > 0 ;
    }
    return false;
  }
}


