import {TypePerson} from "../../Types/TypePerson";

export class PersonModel {
  Id?: number;
  identificacion?: number;
  name?: string;
  surname?: string;
  phone?: string;
  mail?: string;
  direction?: string;
  type?: TypePerson;
  specialization?: string;


  constructor(Identificacion: number, Name: string, Surname: string, Phone: string, Mail: string, Direction: string, type: TypePerson) {
    this.identificacion = Identificacion;
    this.name = Name;
    this.surname = Surname;
    this.phone = Phone;
    this.mail = Mail;
    this.direction = Direction;
    this.type = type;
  }

  onValid(){
    if (this.name && this.identificacion){
      return this.name.length >0 && this.identificacion > 0;
    }
    return false;
  }

  onSpecialization(specialization: Specialization[]){
    specialization.forEach(item=>{
      this.specialization += ("|" + item.name);
    });
    this.specialization = this.specialization?.slice(1);
  }
}

export interface Specialization {
  name: string;
}
