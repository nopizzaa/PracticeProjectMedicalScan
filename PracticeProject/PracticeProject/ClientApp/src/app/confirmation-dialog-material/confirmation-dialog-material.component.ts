import {Component, Inject} from '@angular/core';
import {MAT_DIALOG_DATA, MatDialogRef} from '@angular/material/dialog';

@Component({
  selector: 'app-confirmation-dialog-material',
  templateUrl: './confirmation-dialog-material.component.html',
})

export class ConfirmationDialogMaterialComponent {
  constructor(
    public dialogRef: MatDialogRef<ConfirmationDialogMaterialComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {}

  onNoClick(): void {
    this.dialogRef.close(false);
  }

  onYesClick(): void {
    this.dialogRef.close(true);
  }
}
