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
      Message: "Examen creado con exito"
    };

    const objetCreate: ExamModel = {
      Tittle: "Titulo del examen",
      Description: "Description examen",
      DateFinish: "01/01/2020",
      DateRealization: "01/01/2020"
    };

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
      Message: "Examen actualizado con exito"
    };

    const objetUpdate: ExamModel = {
      ExamId: 1,
      Tittle: "Titulo del examen",
      Description: "Description examen",
      DateFinish: "01/01/2020",
      DateRealization: "01/01/2020"
    };

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
