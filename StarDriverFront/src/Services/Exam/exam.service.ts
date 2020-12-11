import { Injectable } from '@angular/core';
import {HttpGenericService} from "../http-generic/http-generic.service";
import {ExamModel} from "../../Model/Exam/exam-model";

@Injectable({
  providedIn: 'root'
})
export class ExamService extends HttpGenericService<ExamModel, ResponseExam> {
}

export class ResponseExam {
  Message?: string;
  Exam?: ExamModel;
  Examlist?: ExamModel[];
}
