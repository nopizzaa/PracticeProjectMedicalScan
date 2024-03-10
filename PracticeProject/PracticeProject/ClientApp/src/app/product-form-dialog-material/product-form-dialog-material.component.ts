import {Component, Inject} from '@angular/core';
import {MAT_DIALOG_DATA, MatDialogRef} from '@angular/material/dialog';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';

@Component({
  selector: 'app-product-form-dialog-material',
  templateUrl: './product-form-dialog-material.component.html',
  styleUrls: ['./product-form-dialog-material.component.css']
})

export class ProductFormDialogMaterialComponent {
  productForm: FormGroup;

  constructor(
    public dialogRef: MatDialogRef<ProductFormDialogMaterialComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private formBuilder: FormBuilder
  ) {
    this.productForm = this.formBuilder.group({
      id: [data.id || ''],
      manufacturer: [data.manufacturer || '', Validators.compose([Validators.required, Validators.maxLength(50)])],
      name: [data.name || '', Validators.compose([Validators.required, Validators.maxLength(50)])],
      price: [data.price || 0, Validators.compose([Validators.required, Validators.min(0)])],
      description: [data.description || '', Validators.maxLength(150)],
    });
  }

  onCancelClick(): void {
    console.log(this.productForm.errors)
    this.dialogRef.close(); // Close the dialog without saving changes
  }

  onSaveClick(): void {
    if (this.productForm.valid) {
      this.dialogRef.close(this.productForm.value); // Close the dialog and pass the form values
    }
  }
}
