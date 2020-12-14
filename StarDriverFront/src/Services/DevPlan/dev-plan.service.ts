import { Injectable } from '@angular/core';
import { DevPlanModel } from 'src/Model/DevPlan/dev-plan-model';
import {HttpGenericService} from "../http-generic/http-generic.service";

@Injectable({
  providedIn: 'root'
})
export class DevPlanService extends HttpGenericService<DevPlanModel, responseDevPlan>{

}

export  class responseDevPlan {
  message?: string;
  devplan?: DevPlanModel;
  list?: DevPlanModel[];
}
