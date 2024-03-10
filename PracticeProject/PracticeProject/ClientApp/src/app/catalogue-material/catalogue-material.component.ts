import {Component, OnInit, ViewChild} from '@angular/core';
import {MatPaginator} from '@angular/material/paginator';
import {MatSort, Sort} from '@angular/material/sort';
import {ProductService} from "../../services/product.service";
import {ProductDataSource} from "../../services/product.dataSource";
import {MatDialog} from "@angular/material/dialog";
import {DialogDescriptionMaterialComponent} from "../dialog-description-material/dialog-description-material.component";
import {
  ConfirmationDialogMaterialComponent
} from "../confirmation-dialog-material/confirmation-dialog-material.component";
import {
  ProductFormDialogMaterialComponent
} from "../product-form-dialog-material/product-form-dialog-material.component";
import {Product} from "../types/product";
import {NewProduct} from "../types/new-product";

@Component({
  selector: 'app-catalogue-material',
  templateUrl: './catalogue-material.component.html',
  styleUrls: ['./catalogue-material.component.css']
})

export class CatalogueMaterialComponent implements OnInit {
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;
  dataSource = new ProductDataSource(this.productService);

  displayedColumns: string[] = ['id', 'manufacturer', 'name', 'price', 'actions'];

  constructor(private productService: ProductService, public dialog: MatDialog) {
  }

  ngOnInit(): void {
    this.dataSource.loadProducts({active: 'price', direction: 'asc'});
  }

  refreshProducts(): void {
    this.dataSource.loadProducts({active: 'price', direction: 'asc'});
  }

  sortProducts(sort: Sort): void {
    this.dataSource.loadProducts(sort);
  }

  addProduct(newProduct: NewProduct): void {
    this.productService.addProduct(newProduct).subscribe({
      complete: () => this.refreshProducts(),
      error: (error) => alert(`Error removing product: ${error.message}`)
    });
  }

  updateProduct(product: Product): void {
    this.productService.updateProduct(product).subscribe({
      complete: () => this.refreshProducts(),
      error: (error) => alert(`Error removing product: ${error.message}`)
    });
  }

  openDialog(text: string): void {
    this.dialog.open(DialogDescriptionMaterialComponent, {
      width: '250px',
      data: {message: text},
    });
  }

  deleteRowWithConfirmation(element: any): void {
    const dialogRef = this.dialog.open(ConfirmationDialogMaterialComponent, {
      width: '350px'
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.deleteRow(element.id);
      }
    });
  }

  deleteRow(productId: string): void {
    this.productService.removeProduct(productId).subscribe({
      complete: () => this.refreshProducts(),
      error: (error) => alert(`Error removing product: ${error.message}`)
    });
  }

  openProductFormDialog(product: any): void {
    const dialogRef = this.dialog.open(ProductFormDialogMaterialComponent, {
      data: product || {}
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        if (result.id) {
          this.updateProduct(result as Product);
        } else {
          this.addProduct({
            manufacturer: result.manufacturer,
            name: result.name,
            description: result.description,
            price: result.price
          });
        }
      }
    });
  }
}
