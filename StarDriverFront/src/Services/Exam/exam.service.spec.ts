import { TestBed } from '@angular/core/testing';

import {ExamService, ResponseExam} from './exam.service';
import {HttpClient, HttpResponse} from "@angular/common/http";
import {HttpGenericService} from "../http-generic/http-generic.service";
import {HttpClientTestingModule, HttpTestingController} from "@angular/common/http/testing";
import {TestingResponseModel} from "../http-generic/http-generic.service.spec";
import {ExamModel} from "../../Model/Exam/exam-model";

describe('ExamService', () => {
  let httpClient: HttpClient;
  let service: ExamService;
  let httpMock: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [
        HttpClientTestingModule
      ],
      providers: [
        ExamService
      ]
    });

    httpClient = TestBed.inject(HttpClient);
    service = TestBed.inject(ExamService);
    httpMock = TestBed.get(HttpTestingController);
  });

  afterEach(() => {
    httpMock.verify();
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('Crear examen', () => {
    const ExamResponse: ResponseExam = {
      message: "Examen creado con exito"
    };

    let objetCreate = new ExamModel();
    objetCreate.Tittle = "Titulo del examen";
    objetCreate.description = "Description examen";
    objetCreate.dateRealization = "01/01/2020";
    objetCreate.dateRealization = "01/01/2020";

    service.Post("Exam",objetCreate).subscribe(responseExam =>
      expect(responseExam).toEqual(ExamResponse, "Deberia mostrar que se creo el examen exitosamente."), fail
    );

    const req = httpMock.expectOne("https://localhost:5001/api/Exam");
    expect(req.request.method).toEqual('POST');
    expect(req.request.body).toEqual(objetCreate);

    const expectedResponse = new HttpResponse({ status: 201, statusText: 'Created', body: ExamResponse});
    req.event(expectedResponse);
  });

  it('Update examen', () => {
    const ExamResponse: ResponseExam = {
      message: "Examen actualizado con exito"
    };

    let objetUpdate = new ExamModel();
    objetUpdate.ExamId = 1;
    objetUpdate.Tittle = "Titulo del examen";
    objetUpdate.description = "Description examen";
    objetUpdate.dateRealization = "01/01/2020";
    objetUpdate.dateRealization = "01/01/2020";

    service.Put("Exam",objetUpdate).subscribe(responseExam =>
      expect(responseExam).toEqual(ExamResponse, "Deberia mostrar que se actualizo el examen exitosamente."), fail
    );

    const req = httpMock.expectOne("https://localhost:5001/api/Exam");
    expect(req.request.method).toEqual('PUT');
    expect(req.request.body).toEqual(objetUpdate);

    const expectedResponse = new HttpResponse({ status: 201, statusText: 'Updated', body: ExamResponse});
    req.event(expectedResponse);
  });
});
