import {InstructorService} from "../../../../Services/IntructorService/instructor.service";

import { Component, OnInit } from '@angular/core';
import {responseRoom, RoomService} from "../../../../Services/RoomService/room.service";
import {RoomModel} from "../../../../Model/Room/room-model";
import {NgForm} from "@angular/forms";
import {MatSnackBar, MatSnackBarConfig} from "@angular/material/snack-bar";
import {DevPlanModel} from "../../../../Model/DevPlan/dev-plan-model";
import {DevPlanService} from "../../../../Services/DevPlan/dev-plan.service";
import {InstructorModel} from "../../../../Model/Instructor/instructor-model";

@Component({
  selector: 'app-room-form',
  templateUrl: './room-form.component.html',
  styleUrls: ['./room-form.component.css']
})
export class RoomFormComponent implements OnInit {

  response = new responseRoom();
  room = new RoomModel();
  devPlans:DevPlanModel[] = [];
  instructors:InstructorModel[] = [];
  constructor(
    private roomservice: RoomService,
    private instructorService: InstructorService,
    private devPlanService: DevPlanService,
    private _snackBar: MatSnackBar
  ) { }

  ngOnInit(): void {
    Promise.all([
      this.instructorService.Get("Person/Instructors").subscribe(Response => {
        this.instructors = <InstructorModel[]>Response.personlist;
      }),
      this.devPlanService.Get("DevPlans").subscribe(Response => {
        this.devPlans = <DevPlanModel[]>Response.list;

      })
    ]);
  }

  onSubmit(){
    if(!this.room.onValid())  return "Hace falta un titulo";

    this.roomservice.Post("Room", this.room).subscribe(Response =>{
      this.response = Response;
      if(this.response.message){
        this._snackBar.open(this.response.message, 'cerrar', {
          duration: 2000
        });
      }
    }, error => console.log(error));

    return "Datos guardados exitosamente";
  }

  onForm(f: NgForm) {
    //console.log(this.room);
    console.log(this.onSubmit());

  }
}
