import { Component, OnInit } from '@angular/core';

import {COMMA, ENTER, J} from "@angular/cdk/keycodes";
import {MatChipInputEvent} from "@angular/material/chips";
import {PersonService, ResponsePerson} from "../../../Services/PersonService/person.service";
import {PersonModel, Specialization} from "../../../Model/Person/person-model";
import {TypePerson} from "../../../Types/TypePerson";
import {NgForm} from "@angular/forms";
import {MatSnackBar} from "@angular/material/snack-bar";


@Component({
  selector: 'app-person-form',
  templateUrl: './person-form.component.html',
  styleUrls: ['./person-form.component.css']
})


export class PersonFormComponent implements OnInit {
  response = new ResponsePerson();
  person = new PersonModel(0,"","","","","", "Apprentice");
  visible = true;
  selectable = true;
  removable = true;
  addOnBlur = true;
  readonly separatorKeysCodes: number[] = [ENTER, COMMA];
  specializations: Specialization[] = [
    {name: 'Tránsito y Seguridad Vial'},
  ];

  constructor(
    private personService: PersonService,
    private _snackBar: MatSnackBar
  ) {

  }

  ngOnInit(): void {
  }

  onSubmit(): string{
  if (!this.person.onValid()) return "hacen falta identificación y  nombre";
  this.person.onSpecialization(this.specializations);

  this.personService.Post("Person", this.person).subscribe(Response=>{
    this.response = Response;
   if (this.response.message){
     this._snackBar.open(this.response.message, "Cerrar", {
       duration: 2000,
     });
   }
  }, error => console.log(error));

    return "Datos guardados correctamente";

  }



  add(event: MatChipInputEvent): void {
    const input = event.input;
    const value = event.value;

    // Add our specialization
    if ((value || '').trim()) {
      this.specializations.push({name: value.trim()});
    }

    // Reset the input value
    if (input) {
      input.value = '';
    }
  }

  remove(specialization: Specialization): void {
    const index = this.specializations.indexOf(specialization);

    if (index >= 0) {
      this.specializations.splice(index, 1);
    }
  }



  onForm(f: NgForm) {

    console.log(this.onSubmit());
    console.log(JSON.stringify(this.person))
  }

  openSnackBar() {
    this._snackBar.openFromComponent(PersonFormComponent, {
      duration: 2000,
    });
  }
}



