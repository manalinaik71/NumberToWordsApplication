import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';


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

  constructor(private http: HttpClient) { }

  ConvertNumberToWords(request: NumberConversionRequest) {

    const apiURL = 'http://localhost:5297/api/NumberConversion/convert';

    return this.http.post<NumberConversionResponse>(apiURL, request);
  }
}
