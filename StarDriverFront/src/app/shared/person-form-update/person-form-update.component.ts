import {Component, OnInit, Output, Inject, EventEmitter} from '@angular/core';
import {PersonService, ResponsePerson} from "../../../Services/PersonService/person.service";
import {PersonModel, Specialization} from "../../../Model/Person/person-model";
import {COMMA, ENTER} from "@angular/cdk/keycodes";
import {MatSnackBar} from "@angular/material/snack-bar";
import {MatChipInputEvent} from "@angular/material/chips";
import {NgForm} from "@angular/forms";
import {MAT_DIALOG_DATA, MatDialogRef} from "@angular/material/dialog";
import {PersonFormComponent} from "../person-form/person-form.component";

@Component({
  selector: 'app-person-form-update',
  templateUrl: './person-form-update.component.html',
  styleUrls: ['./person-form-update.component.css']
})
export class PersonFormUpdateComponent implements OnInit {


  response = new ResponsePerson();
  person : PersonModel;
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
    private _snackBar: MatSnackBar,
    private dialogRef: MatDialogRef<PersonFormComponent>,
    @Inject(MAT_DIALOG_DATA) public data: PersonModel
  ) {
    this.person = data;

  }


  ngOnInit(): void {
    console.log(this.person);
  }



  onSubmit(): string{

     this.personService.Put("Person", this.person).subscribe(Response=>{
      this.response = Response;
      if (this.response.message){
        this._snackBar.open(this.response.message, "Cerrar", {
          duration: 2000,
        });
      }
    }, error => console.log(error));

    return "Datos actualizados correctamente";

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
}
