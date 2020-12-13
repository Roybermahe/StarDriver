import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ClassRoomComponent } from './class-room.component';
import {angularMaterialModule} from "../angularMaterial.module";

describe('ClassRoomComponent', () => {
  let component: ClassRoomComponent;
  let fixture: ComponentFixture<ClassRoomComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ClassRoomComponent ],
      imports: [angularMaterialModule]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ClassRoomComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
