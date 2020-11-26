import {getTestBed, TestBed} from '@angular/core/testing';

import { HttpGenericService } from './http-generic.service';
import {HttpClientTestingModule, HttpTestingController} from "@angular/common/http/testing";

describe('HttpGenericService', () => {
  let injector: TestBed;
  let service: HttpGenericService<object, string>;
  let httpMock: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [ HttpClientTestingModule ]
    });
    injector = getTestBed();
    service = TestBed.inject(HttpGenericService);
    httpMock = injector.get(HttpTestingController);
  });

  afterEach(() => {
    httpMock.verify();
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
