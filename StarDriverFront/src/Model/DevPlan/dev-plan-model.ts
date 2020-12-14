export class DevPlanModel {
  id?: number;
  level?: string;

  constructor(level?: string) {
    this.level = level;
  }


  onValid() {
    if(this.level){
      return this.level?.toString().length > 0 ;
    }
    return false;
  }
}
