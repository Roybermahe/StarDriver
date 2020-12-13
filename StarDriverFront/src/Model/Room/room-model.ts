export class RoomModel {
  RoomId?: number;
  Name?: string;
  Description?: string;
  State?: string;
  IdInsturctor?: number;
  IdDevPlan?: number;

constructor() {
  this.Name = "";
}


  onValid() {
    if(this.Name){
      return this.Name?.length > 0 ;
    }
    return false;

  }
}


