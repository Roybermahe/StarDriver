export class RoomModel {
  RoomId?: number;
  Name?: string;
  Description?: string;
  State?: string;
  IdInsturctor?: string;
  IdDevPlan?: string;

constructor() {
  this.Name = "";
}


  onValid() {
    if(this.Name && this.RoomId){
      return this.Name?.length > 0 ;
    }
    return false;

  }
}


