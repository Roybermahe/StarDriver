import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {Observable} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class HttpGenericService<T, M extends String> {

  private readonly END_POINT: string;

  constructor(
    private readonly http: HttpClient
  ) {
    this.END_POINT = "https://localhost:5001/api";
  }

  async Get(route: string) {
    return this.http.get<T>(`${this.END_POINT}/${route}`);
  }

  async Post(route: string, body: T) {
    return this.http.post<M>(`${this.END_POINT}/${route}`, body);
  }

  async Put(route: string, body: T) {
    return this.http.put<M>(`${this.END_POINT}/${route}`, body);
  }

  async Delete(route: string, id: number) {
    return this.http.delete<M>(`${this.END_POINT}/${route}`);
  }
}
