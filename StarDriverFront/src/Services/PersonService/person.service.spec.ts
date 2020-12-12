import { TestBed } from '@angular/core/testing';

import {PersonService, ResponsePerson} from './person.service';
import {HttpClientTestingModule, HttpTestingController} from "@angular/common/http/testing";
import {HttpClient, HttpResponse} from "@angular/common/http";
import {PersonModel} from "../../Model/Person/person-model";


describe('PersonService', () => {
  let httpClient: HttpClient;
  let service: PersonService;
  let httpMock: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [
        HttpClientTestingModule
      ],
      providers :[
        PersonService
      ],
    });

    httpClient = TestBed.inject(HttpClient);
    service = TestBed.inject(PersonService);
    httpMock = TestBed.get(HttpTestingController);
  });

  afterEach(() => {
    httpMock.verify();
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('Guardar persona', () => {
    const PersonResponse: ResponsePerson = {
      Message : "Se guardo la persona"
    };

    let objecCreate = new  PersonModel();

    objecCreate.Identificacion = 1003385884;
    objecCreate.Name= "Eva Camacho";
    objecCreate.Surname= "Romero Cardeño";
    objecCreate.Phone= "3106405582";
    objecCreate.Mail= "Eva@gmail.com";
    objecCreate.Direction= "Nanado Marin";



    service.Post("Person", objecCreate).subscribe(responsePerson =>
      expect(responsePerson).toEqual(PersonResponse, " Deberia mostrar que se creo la persona correctamente"), fail
    );

    const req = httpMock.expectOne("https://localhost:5001/api/Person");
    expect(req.request.method).toEqual('POST');
    expect(req.request.body).toEqual(objecCreate);
    const expectedResponse = new HttpResponse({ status: 201, statusText: 'Created', body: PersonResponse });
    req.event(expectedResponse);
  });

  it('Actualizar persona caso fallido', () => {
    const PersonResponse: ResponsePerson = {
      Message : "Se necesita el id para actualizar"
    };

    let objecCreate = new  PersonModel();

    objecCreate.Identificacion = 1003385884;
    objecCreate.Name= "Eva Camacho";
    objecCreate.Surname= "Romero Cardeño";
    objecCreate.Phone= "3106405582";
    objecCreate.Mail= "Eva@gmail.com";
    objecCreate.Direction= "Nanado Marin";

    service.Put("Person", objecCreate).subscribe(responsePerson =>
      expect(responsePerson).toEqual(PersonResponse, "Se debe indicar una ID"), fail
    );

    const req = httpMock.expectOne("https://localhost:5001/api/Person");
    expect(req.request.method).toEqual('PUT');
    expect(req.request.body).toEqual(objecCreate);
    const expectedResponse = new HttpResponse({ status: 404, statusText: 'Failed', body: PersonResponse });
    req.event(expectedResponse);

  });

  it('Actualizar persona', () => {
    const PersonResponse: ResponsePerson = {
      Message : "Se necesita el id para actualizar"
    };

    let objecCreate = new  PersonModel();

    objecCreate.Identificacion = 1003385884;
    objecCreate.Name= "Eva Camacho";
    objecCreate.Surname= "Romero Cardeño";
    objecCreate.Phone= "3106405582";
    objecCreate.Mail= "Eva@gmail.com";
    objecCreate.Direction= "Nanado Marin";

    service.Put("Person", objecCreate).subscribe(responsePerson =>
      expect(responsePerson).toEqual(PersonResponse, "Se debe indicar una ID"), fail
    );

    const req = httpMock.expectOne("https://localhost:5001/api/Person");
    expect(req.request.method).toEqual('PUT');
    expect(req.request.body).toEqual(objecCreate);
    const expectedResponse = new HttpResponse({ status: 201, statusText: 'Update', body: PersonResponse });
    req.event(expectedResponse);

  });

  it('Obtener lista persona', () => {
    let objecCreate = new  PersonModel();

    objecCreate.Identificacion = 1003385884;
    objecCreate.Name= "Eva Camacho";
    objecCreate.Surname= "Romero Cardeño";
    objecCreate.Phone= "3106405582";
    objecCreate.Mail= "Eva@gmail.com";
    objecCreate.Direction= "Nanado Marin";
    const PersonResponse: ResponsePerson = {
      Message : "Se necesita el id para obtener a la persona",
      Personlist: [objecCreate]
    };


    service.Get("Person").subscribe(responsePerson =>
      expect(responsePerson).toEqual(PersonResponse, "Se debe indicar una ID"), fail
    );

    const req = httpMock.expectOne("https://localhost:5001/api/Person");
    expect(req.request.method).toEqual('GET');
    const expectedResponse = new HttpResponse({ status: 201, statusText: 'Requested', body: PersonResponse });
    req.event(expectedResponse);

  });

  it('Obtener persona', () => {
    let objecCreate = new  PersonModel();

    objecCreate.Identificacion = 1003385884;
    objecCreate.Name= "Eva Camacho";
    objecCreate.Surname= "Romero Cardeño";
    objecCreate.Phone= "3106405582";
    objecCreate.Mail= "Eva@gmail.com";
    objecCreate.Direction= "Nanado Marin";

    const PersonResponse: ResponsePerson = {
      Message : "Se necesita el id para obtener a la persona",
      Person: objecCreate
    };


    service.Get("Person").subscribe(responsePerson =>
      expect(responsePerson).toEqual(PersonResponse, "Se debe indicar una ID"), fail
    );

    const req = httpMock.expectOne("https://localhost:5001/api/Person");
    expect(req.request.method).toEqual('GET');
    const expectedResponse = new HttpResponse({ status: 201, statusText: 'Requested', body: PersonResponse });
    req.event(expectedResponse);

  });
});
