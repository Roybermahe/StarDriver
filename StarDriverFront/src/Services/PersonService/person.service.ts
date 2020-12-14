import { Injectable } from '@angular/core';
import {HttpGenericService} from "../http-generic/http-generic.service";
import {PersonModel} from "../../Model/Person/person-model";

@Injectable({
  providedIn: 'root'
})
export class PersonService extends HttpGenericService<PersonModel, ResponsePerson> {


}

export class  ResponsePerson{
  message?: string;
  person?: PersonModel;
  personlist?: PersonModel[];
}
