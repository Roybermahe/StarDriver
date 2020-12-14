import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ExamsComponent } from './exams.component';
import {angularMaterialModule} from "../angularMaterial.module";

describe('ExamsComponent', () => {
  let component: ExamsComponent;
  let fixture: ComponentFixture<ExamsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ExamsComponent ],
      imports: [ angularMaterialModule ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ExamsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('Componente Creado', () => {
    expect(component).toBeTruthy();
  });
});
