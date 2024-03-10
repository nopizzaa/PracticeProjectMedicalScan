import {Inject, Injectable} from "@angular/core";
import {Observable} from "rxjs";
import {Product} from "../app/product";
import {HttpClient, HttpParams} from "@angular/common/http";
import { Sort } from '@angular/material/sort';

@Injectable()
export class ProductService{
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {}

  fetchProducts(sort: Sort): Observable<Product[]> {
    const params = new HttpParams()
      .set('_sort', sort.active)
      .set('_order', sort.direction);
    return this.http.get<Product[]>(this.baseUrl + 'api/product', {params})
  }
}
