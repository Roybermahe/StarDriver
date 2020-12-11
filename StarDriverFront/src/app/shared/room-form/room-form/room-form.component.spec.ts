import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RoomFormComponent } from './room-form.component';
import {HttpClientTestingModule} from "@angular/common/http/testing";
import {ResponseRoom, RoomService} from "../../../../Services/RoomService/room.service";
import {RoomModel} from "../../../../Model/Room/room-model";

describe('RoomFormComponent', () => {
  let component: RoomFormComponent;
  let fixture: ComponentFixture<RoomFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RoomFormComponent ],
      imports:[
        HttpClientTestingModule
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
    expect(component.response).toBeDefined(ResponseRoom);

    expect(component.room).toEqual(new RoomModel());
    expect(component.response).toEqual( new ResponseRoom());
  });

  it('No puede hacer submit con el nombre vacio', () =>{
    expect(component.onSubmit).toEqual("hace falta el nombre");
  });
});
