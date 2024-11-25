import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, map } from 'rxjs';
import { Category } from '../category/Category.interface';
import { environment } from '../environment/environment';
import { HttpParams } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class CategoryService {
  public baseApiUrl: string = environment.apiUrL;

  constructor(private http: HttpClient) {}

  getCategory(id: number | undefined): Observable<Category> {
    return this.http.get(this.baseApiUrl + '/Category/GetCategory/' + id);
  }

  getCategories(parentId: number | null): Observable<Category[]> {
    let params = new HttpParams();
    if (parentId !== null) {
      params = params.set('parentId', parentId.toString());
    }
    return this.http
      .get<Category[]>(`${this.baseApiUrl}/Category/GetCategories`, { params })
      .pipe(
        map((categories) =>
          categories.map((category) => ({
            ...category,
            route: `/categories/${category.id}`,
          }))
        )
      );
  }
}
