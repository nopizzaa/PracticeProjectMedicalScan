import {Component, OnInit, ViewChild} from '@angular/core';
import {MatPaginator} from '@angular/material/paginator';
import {MatSort, Sort} from '@angular/material/sort';
import {ProductService} from "../../services/product.service";
import {ProductDataSource} from "../../services/product.dataSource";
import {MatDialog} from "@angular/material/dialog";
import {DialogDescriptionMaterialComponent} from "../dialog-description-material/dialog-description-material.component";

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
    console.log('Sort Event:', sort);
    this.dataSource.loadProducts(sort);
  }

  editRow(row: any): void {
    console.log('Edit row:', row);
  }

  deleteRow(row: any): void {
    console.log('Delete row:', row);
  }

  openDialog(text: string): void {
    const dialogRef = this.dialog.open(DialogDescriptionMaterialComponent, {
      width: '250px',
      data: {message: text},
    });
  }
}
