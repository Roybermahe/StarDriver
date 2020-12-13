import {HttpClient, HttpResponse} from '@angular/common/http';
import { TestBed } from '@angular/core/testing';

import {responseRoom, RoomService} from './room.service';
import {HttpClientTestingModule, HttpTestingController} from "@angular/common/http/testing";
import {RoomModel} from "../../Model/Room/room-model";

describe('RoomService', () => {
  let httpClient: HttpClient;
  let service: RoomService;
  let httpMock: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports:[
        HttpClientTestingModule
      ],
      providers:[
        RoomService
      ]
    });
    httpClient = TestBed.inject(HttpClient);
    service = TestBed.inject(RoomService);
    httpMock = TestBed.get(HttpTestingController);

  });

  afterEach(() => {
    httpMock.verify();
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('Crear salon', () =>{
    const RoomResoponse: responseRoom = {
      Message: "salon creado con exito"
    };

    let objetCreate = new RoomModel();
      objetCreate.Name = "Nombre del salon";
      objetCreate.Description = "Descripción del salon";
      objetCreate.State = "Estado para el salon";
      objetCreate.IdInsturctor = 1;
      objetCreate.IdDevPlan = 1;


    service.Post("Room", objetCreate).subscribe(responseRoom =>
      expect(responseRoom).toEqual(RoomResoponse,"Deveria mostrar que se creo un salon." ), fail
    );

    const req = httpMock.expectOne("https://localhost:5001/api/Room");
    expect(req.request.method).toEqual('POST');
    expect(req.request.body).toEqual(objetCreate);

    const expectedResponse = new HttpResponse({ status: 201, statusText: 'Created', body: RoomResoponse });
    req.event(expectedResponse);
  });


  // terminar
  it('Consultar Salones', () =>{

    let objetquery = new RoomModel();
    objetquery.RoomId = 1;
      objetquery.Name = "Nombre del salon";
      objetquery.Description = "Descripción del salon";
      objetquery.State = "Estado para el salon";
      objetquery.IdInsturctor = 1;
      objetquery.IdDevPlan = 1;

    const RoomResoponse: responseRoom = {
      Message: "consulta realizada con exito",
      Roomlist:[objetquery]
    };

    service.Get("Room").subscribe(responseRoom =>
      expect(responseRoom).toEqual(RoomResoponse,"Deberia mostrar una lista de salones." ), fail
    );

    const req = httpMock.expectOne("https://localhost:5001/api/Room");
    expect(req.request.method).toEqual('GET');

    const expectedResponse = new HttpResponse({ status: 404, statusText: 'consulted', body: RoomResoponse });
    req.event(expectedResponse);
  });


  it('Update room', () =>{

    let objetUpdate = new RoomModel();
      objetUpdate.RoomId = 1;
      objetUpdate.Name = "Nombre del salon";
      objetUpdate.Description = "Descripción del salon";
      objetUpdate.State = "Estado para el salon";
      objetUpdate.IdInsturctor = 1;
      objetUpdate.IdDevPlan = 1;

    const RoomResoponse: responseRoom = {
      Message: "actualización realizada con exito",
    };

    service.Put("Room", objetUpdate).subscribe(responseRoom =>
      expect(responseRoom).toEqual(RoomResoponse,"Deberia mostrar que se actualizo el salon exitosamente." ), fail
    );

    const req = httpMock.expectOne("https://localhost:5001/api/Room");
    expect(req.request.method).toEqual('PUT');
    expect(req.request.body).toEqual(objetUpdate);

    const expectedResponse = new HttpResponse({ status: 201, statusText: 'Updated', body: RoomResoponse });
    req.event(expectedResponse);
  });
});
