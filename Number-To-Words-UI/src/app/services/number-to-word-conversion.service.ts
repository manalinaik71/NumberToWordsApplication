import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';


export interface NumberConversionRequest {
  number: number;
  cents: number;
  language: string;
}

export interface NumberConversionResponse {
  words: string;
}

@Injectable({
  providedIn: 'root'
})
export class NumberToWordConversionService {
  private readonly apiUrl = 'http://localhost:5297/api/NumberConversion/convert';
  constructor(private http: HttpClient) { }

  convertNumberToWords(request: NumberConversionRequest): Observable<NumberConversionResponse> {

    return this.http.post<NumberConversionResponse>(this.apiUrl, request);
  }
}
