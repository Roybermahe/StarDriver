import { Injectable } from '@angular/core';
import {InstructorModel} from "../../Model/Instructor/instructor-model";
import {ApprenticeModel} from "../../Model/Apprentice/apprentice-model";
import {HttpGenericService} from "../http-generic/http-generic.service";

@Injectable({
  providedIn: 'root'
})
export class ApprenticeService extends HttpGenericService<ApprenticeModel, ResponseApprentice>{
}

export class ResponseApprentice {
  message?:string;
  person?: ApprenticeModel;
  personlist?: ApprenticeModel[];
}
