import {Inject, Injectable} from "@angular/core";
import {Observable} from "rxjs";
import {HttpClient, HttpHeaders, HttpParams} from "@angular/common/http";
import {Sort} from '@angular/material/sort';
import {NewProduct} from "../app/types/new-product";
import {Product} from "../app/types/product";

@Injectable()
export class ProductService {
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {}

  fetchProducts(sort: Sort): Observable<Product[]> {
    const params = new HttpParams()
      .set('Active', sort.active)
      .set('Direction', sort.direction);
    return this.http.get<Product[]>(this.baseUrl + 'api/product', {params})
  }

  removeProduct(productId: string): Observable<void> {
    const params = new HttpParams()
      .set('productId', productId);
    return this.http.delete<void>(this.baseUrl + 'api/product/', {params});
  }

  addProduct(newProduct: NewProduct): Observable<void> {
    const headers = new HttpHeaders({'Content-Type': 'application/json'});

    return this.http.post<void>(this.baseUrl + 'api/product', JSON.stringify(newProduct), {headers: headers});
  }

  updateProduct(product: Product): Observable<void> {
    const headers = new HttpHeaders({'Content-Type': 'application/json'});

    return this.http.put<void>(this.baseUrl + 'api/product', JSON.stringify(product), {headers: headers});
  }
}
