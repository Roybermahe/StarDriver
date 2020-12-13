export class DevPlanModel {
  DevPlanId?: number;
  Level?: string;

  constructor() {
    this.DevPlanId;
  }


  onValid() {
    if(this.DevPlanId){
      return this.DevPlanId?.toString().length > 0 ;
    }
    return false;

  }
}
