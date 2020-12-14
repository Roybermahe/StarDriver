import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PersonFormComponent } from './person-form.component';
import {HttpClientTestingModule} from "@angular/common/http/testing";
import {angularMaterialModule} from "../../angularMaterial.module";
import {PersonService, ResponsePerson} from "../../../Services/PersonService/person.service";
import {PersonModel} from "../../../Model/Person/person-model";




describe('PersonFormComponent', () => {
  let component: PersonFormComponent;
  let fixture: ComponentFixture<PersonFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PersonFormComponent ],
      imports: [
        HttpClientTestingModule,
        angularMaterialModule
      ],
      providers :[
        PersonService
      ],
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PersonFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
    expect(component.person).toBeDefined(PersonModel);
    expect(component.response).toBeDefined(ResponsePerson);
    expect(component.person).toEqual(new PersonModel(0,"","","","","", "Apprentice"));
    expect(component.response).toEqual(new ResponsePerson());
  });

  it('No puede hacer submit con los identificación y nombre vacios', function () {
    expect(component.onSubmit()).toEqual("hacen falta identificación y  nombre");
  });

  it('Enviar petición submit con la identificacion y el nombre llenos', () => {
    component.person.Identificacion= 1003376884;
    component.person.Name="Ingreso un valor";
    expect(component.onSubmit()).toEqual("Datos guardados correctamente");
  });
});
