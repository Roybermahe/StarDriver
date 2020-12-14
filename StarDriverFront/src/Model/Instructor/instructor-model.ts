export class InstructorModel {
  id?: number;
  identificacion?: string;
  name?: string;
  surname?: string;
  phone?: string;
  mail?: string;
  direction?: string;


  constructor(id?: number, identificacion?: string, name?: string, surname?: string, phone?: string, mail?: string, direction?: string) {
    this.id = id;
    this.identificacion = identificacion;
    this.name = name;
    this.surname = surname;
    this.phone = phone;
    this.mail = mail;
    this.direction = direction;
  }
}
