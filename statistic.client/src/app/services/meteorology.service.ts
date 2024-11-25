import { HttpClient, HttpParams } from '@angular/common/http';
import { MeteorologyResponse } from '../data/meteorology/Meteorology.interface';
import { Observable } from 'rxjs';
import { environment } from '../environment/environment';
import { Injectable } from '@angular/core';
import { Contact } from '../data/Contact.interface';
import { Source } from '../data/Source.interface';

@Injectable({
  providedIn: 'root',
})
export class MeteorologyService {
  public baseApiUrl: string = environment.apiUrL;

  constructor(private http: HttpClient) {}

  getMeteorologyData(
    filters: {
      year?: number[];
      month?: string[];
      categoryId?: number;
      sourceId?: number;
    },
    page: number,
    pageSize: number
  ): Observable<MeteorologyResponse> {
    let params = new HttpParams()
      .set('page', page.toString())
      .set('pageSize', pageSize.toString());

    Object.entries(filters).forEach(([key, value]) => {
      if (value !== undefined && value !== null) {
        if (Array.isArray(value)) {
          params = params.set(key, value.join(','));
        } else {
          params = params.set(key, value.toString());
        }
      }
    });

    return this.http.get<MeteorologyResponse>(
      `${this.baseApiUrl}/Meteorology/GetMeteorologyData`,
      { params }
    );
  }

  getDistinctMonths(): Observable<string[]> {
    return this.http.get<string[]>(
      `${this.baseApiUrl}/Meteorology/GetMonthsAsync`
    );
  }

  getDistinctYears(): Observable<number[]> {
    return this.http.get<number[]>(
      `${this.baseApiUrl}/Meteorology/GetYearsAsync`
    );
  }

  exportToExcel(params: HttpParams): Observable<Blob> {
    return this.http.get<Blob>(`${this.baseApiUrl}/Meteorology/ExportToExcel`, {
      params: params,
      responseType: 'blob' as 'json',
    });
  }

  getContact(id: number | undefined): Observable<Contact> {
    return this.http.get(this.baseApiUrl + '/Contact/GetContact/' + id);
  }

  getSource(id: number | undefined): Observable<Source> {
    return this.http.get(this.baseApiUrl + '/Source/GetSource/' + id);
  }
}
