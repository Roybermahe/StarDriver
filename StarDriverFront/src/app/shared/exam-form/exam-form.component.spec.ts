import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ExamFormComponent } from './exam-form.component';
import {HttpClientTestingModule} from "@angular/common/http/testing";
import {ExamService, ResponseExam} from "../../../Services/Exam/exam.service";
import {ExamModel} from "../../../Model/Exam/exam-model";
import {angularMaterialModule} from "../../angularMaterial.module";

describe('ExamFormComponent', () => {
  let component: ExamFormComponent;
  let fixture: ComponentFixture<ExamFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ExamFormComponent ],
      imports: [
        HttpClientTestingModule,
        angularMaterialModule
      ],
      providers: [
        ExamService
      ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ExamFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
    expect(component.exam).toBeDefined(ExamModel);
    expect(component.response).toBeDefined(ResponseExam);
    expect(component.exam).toEqual(new ExamModel());
    expect(component.response).toEqual(new ResponseExam());
  });

  it('No puede hacer submit con el title y el description vacios', () => {
      expect(component.onSubmit()).toEqual("Hacen falta title y descripcion");
  });

  it('Enviar petición submit con el title y el description llenos', () => {
    component.exam.Tittle="Ingreso un valor";
    component.exam.description="Ingreso un valor";
    expect(component.onSubmit()).toEqual("Datos guardados exitosamente");
  });
});
