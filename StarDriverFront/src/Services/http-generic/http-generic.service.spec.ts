import { TestBed } from '@angular/core/testing';

import { HttpGenericService } from './http-generic.service';
import {HttpClientTestingModule, HttpTestingController} from "@angular/common/http/testing";
import {HttpClient, HttpResponse} from "@angular/common/http";

describe('HttpGenericService', () => {
  let httpClient: HttpClient;
  let service: HttpGenericService<object, TestingResponseModel>;
  let httpMock: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [ HttpClientTestingModule ],
      providers: [
        HttpGenericService
      ]
    });
    httpClient = TestBed.inject(HttpClient);
    service = TestBed.inject(HttpGenericService);
    httpMock = TestBed.get(HttpTestingController);
  });

  afterEach(() => {
    httpMock.verify();
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('Post Object', () => {
    const responseStyle: TestingResponseModel = {
      Message: "Se creo el examen correctamente."
    };
    const someObject = {
      title: "Examen Nuevo",
      Description: "Examen definitivo",
      DateRealization: "01/02/2020",
      DateFinish: "01/02/2020"
    };

    service.Post("Exam", someObject).subscribe( Response =>
        expect(Response).toEqual(responseStyle, 'Deberia mostrar el response del controller.'), fail
    );

    const req = httpMock.expectOne("https://localhost:5001/api/Exam");
    expect(req.request.method).toEqual('POST');
    expect(req.request.body).toEqual(someObject);

    const expectedResponse = new HttpResponse({ status: 201, statusText: 'Created', body: responseStyle });
    req.event(expectedResponse);
  });

  it('Get Objects', () => {
    const someListObject = [{
      title: "Examen Nuevo",
      Description: "Examen definitivo",
      DateRealization: "01/02/2020",
      DateFinish: "01/02/2020"
    }];
    const responseObject: TestingResponseModel = {
      Message: "mostrando lista de objetos",
      List: someListObject
    };

    service.Get("Exam").subscribe( Response =>
      expect(Response).toEqual(responseObject, 'Deberia mostrar la lista de objetos'), fail
    );

    const req = httpMock.expectOne("https://localhost:5001/api/Exam");
    expect(req.request.method).toEqual('GET');
    const expectedResponse = new HttpResponse({ status: 201, statusText: 'Requested', body: responseObject });
    req.event(expectedResponse);
  });

  it('Put Object',() => {
    const responseStyle: TestingResponseModel = {
      Message: "Se actualizo el examen correctamente."
    };
    const someObject = {
      Id: 1,
      title: "Examen Nuevo",
      Description: "Examen definitivo",
      DateRealization: "01/02/2020",
      DateFinish: "01/02/2020"
    };

    service.Put("Exam", someObject).subscribe( Response =>
      expect(Response).toEqual(responseStyle, 'Deberia mostrar el mensaje del response.'), fail
    );
    const req = httpMock.expectOne("https://localhost:5001/api/Exam");
    expect(req.request.method).toEqual('PUT');
    expect(req.request.body).toEqual(someObject);

    const expectedResponse = new HttpResponse({ status: 201, statusText: 'Created', body: responseStyle });
    req.event(expectedResponse);
  });

  it('Delete Object', () => {
    const responseStyle: TestingResponseModel = {
      Message: "Se elimino el examen correctamente."
    };
    const Id = 1;
    service.Delete("Exam", Id).subscribe( Response =>
      expect(Response).toEqual(responseStyle, 'Deberia mostrar el mensaje del response.'), fail
    );

    const req = httpMock.expectOne("https://localhost:5001/api/Exam/1");
    expect(req.request.method).toEqual('DELETE');
    const expectedResponse = new HttpResponse({ status: 201, statusText: 'Deleted', body: responseStyle });
    req.event(expectedResponse);
  });
});


export class TestingResponseModel {
  public Message?: string;
  public List?: object[];
  constructor() {
    this.Message = "";
  }
}
