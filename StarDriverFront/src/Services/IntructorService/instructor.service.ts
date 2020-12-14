import { Injectable } from '@angular/core';
import {HttpGenericService} from "../http-generic/http-generic.service";
import {InstructorModel} from "../../Model/Instructor/instructor-model";

@Injectable({
  providedIn: 'root'
})
export class InstructorService extends HttpGenericService<InstructorModel, ResponseInstructor> {
}

export class ResponseInstructor {
  message?:string;
  person?: InstructorModel;
  personlist?: InstructorModel[];
}
