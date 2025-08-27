
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Society, CreateSociety } from '../models/society.model';

@Injectable({
  providedIn: 'root'
})
export class SocietyService {
  private readonly API_URL = 'http://localhost:5000/api/societies';

  constructor(private http: HttpClient) {}

  getSocieties(): Observable<Society[]> {
    return this.http.get<Society[]>(this.API_URL);
  }

  getSociety(id: number): Observable<Society> {
    return this.http.get<Society>(`${this.API_URL}/${id}`);
  }

  createSociety(society: CreateSociety): Observable<Society> {
    return this.http.post<Society>(this.API_URL, society);
  }

  updateSociety(id: number, society: Partial<Society>): Observable<Society> {
    return this.http.put<Society>(`${this.API_URL}/${id}`, society);
  }

  deleteSociety(id: number): Observable<void> {
    return this.http.delete<void>(`${this.API_URL}/${id}`);
  }
}
