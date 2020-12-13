import {TypePerson} from "../../Types/TypePerson";

export class PersonModel {
  Id?: number;
  Identificacion?: number;
  Name?: string;
  Surname?: string;
  Phone?: string;
  Mail?: string;
  Direction?: string;
  type?: TypePerson;
  Specialization?: string;


  constructor(Identificacion: number, Name: string, Surname: string, Phone: string, Mail: string, Direction: string, type: TypePerson) {
    this.Identificacion = Identificacion;
    this.Name = Name;
    this.Surname = Surname;
    this.Phone = Phone;
    this.Mail = Mail;
    this.Direction = Direction;
    this.type = type;
  }

  onValid(){
    if (this.Name && this.Identificacion){
      return this.Name.length >0 && this.Identificacion > 0;
    }
    return false;
  }

  onSpecialization(specialization: Specialization[]){
    specialization.forEach(item=>{
      this.Specialization += ("|" + item.name);
    });
    this.Specialization = this.Specialization?.slice(1);
  }
}

export interface Specialization {
  name: string;
}
