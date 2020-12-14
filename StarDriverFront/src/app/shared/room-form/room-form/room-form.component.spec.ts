import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RoomFormComponent } from './room-form.component';
import {HttpClientTestingModule} from "@angular/common/http/testing";
import {responseRoom, RoomService} from "../../../../Services/RoomService/room.service";
import {RoomModel} from "../../../../Model/Room/room-model";
import {angularMaterialModule} from "../../../angularMaterial.module";

describe('RoomFormComponent', () => {
  let component: RoomFormComponent;
  let fixture: ComponentFixture<RoomFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RoomFormComponent ],
      imports:[
        HttpClientTestingModule,
        angularMaterialModule
      ],
      providers:[
        RoomService
      ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RoomFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
    expect(component.room).toBeDefined(new RoomModel());
    expect(component.response).toBeDefined(responseRoom);

    expect(component.room).toEqual(new RoomModel());
    expect(component.response).toEqual( new responseRoom());
  });

  it('No puede hacer submit con el nombre vacio', () =>{
    expect(component.onSubmit).toEqual("hace falta el nombre");
  });

  it('Enviar petición submit con el nombre y el description llenos', () => {
    component.room.name="Ingreso un valor";
    component.room.description="Ingreso un valor";
    expect(component.onSubmit()).toEqual("Datos guardados exitosamente");
  });
});
