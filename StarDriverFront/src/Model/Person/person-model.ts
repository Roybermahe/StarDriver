export class PersonModel {
  Id?: number;
  Identificacion?: number;
  Name?: string;
  Surname?: string;
  Phone?: string;
  Mail?: string;
  Direction?: string;

  constructor() {
    this.Identificacion = 0;
    this.Name = "";
    this.Surname = "";
    this.Phone = "";
    this.Mail = "";
    this.Direction = "";
  }

  onValid(){
    if (this.Name && this.Identificacion){
      return this.Name.length >0 && this.Identificacion > 0;
    }
    return false;
  }
}
