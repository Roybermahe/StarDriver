import {HttpClient, HttpHeaders} from "@angular/common/http";
import {Observable} from "rxjs";
import {Injectable} from "@angular/core";
/**
 * T Representa el body que será procesado
 * M Representa la respuesta que se va a recibir
 * */
@Injectable({
  providedIn: 'root'
})
export class HttpGenericService<T, M> {

  private readonly END_POINT: string;

  constructor(
    private readonly http: HttpClient
  ) {
    this.END_POINT = "https://localhost:44376/api";
  }

  Get(route: string): Observable<M> {
    return this.http.get<M>(`${this.END_POINT}/${route}`);
  }

  Post(route: string, body: T): Observable<M> {
    return this.http.post<M>(`${this.END_POINT}/${route}`, body);
  }

  Put(route: string, body: T): Observable<M> {
    return this.http.put<M>(`${this.END_POINT}/${route}`, body);
  }

  Delete(route: string, id: number): Observable<M> {
    return this.http.delete<M>(`${this.END_POINT}/${route}/${id}`);
  }
}
