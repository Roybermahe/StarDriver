import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PersonFormUpdateComponent } from './person-form-update.component';

describe('PersonFormUpdateComponent', () => {
  let component: PersonFormUpdateComponent;
  let fixture: ComponentFixture<PersonFormUpdateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PersonFormUpdateComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PersonFormUpdateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
