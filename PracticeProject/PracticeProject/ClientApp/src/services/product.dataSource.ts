import {Injectable} from "@angular/core";
import {CollectionViewer, DataSource} from "@angular/cdk/collections";
import {Product} from "../app/product";
import {BehaviorSubject, Observable} from "rxjs";
import {ProductService} from "./product.service";
import { Sort } from '@angular/material/sort';

@Injectable()
export class ProductDataSource extends DataSource<Product> {
  products$ = new BehaviorSubject<Product[]>([]);

  constructor(private productService: ProductService) {
    super();
  }

  connect(): Observable<Product[]> {
    return this.products$.asObservable();
  }

  disconnect(collectionViewer: CollectionViewer): void {
    this.products$.complete();
  }

  loadProducts(sort: Sort): void {
    this.productService.fetchProducts(sort).subscribe((products) => {
      this.products$.next(products);
    })
  }
}
