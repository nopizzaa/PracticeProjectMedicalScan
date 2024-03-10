import {Component, Inject} from '@angular/core';
import {MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';

@Component({
    selector: 'app-dialog-description-material',
    templateUrl: './dialog-description-material.component.html',
})

export class DialogDescriptionMaterialComponent {
    message: string;

    constructor(
        public dialogRef: MatDialogRef<DialogDescriptionMaterialComponent>,
        @Inject(MAT_DIALOG_DATA) public data: { message: string }
    ) {
        this.message = data.message;
    }

    onCloseClick(): void {
        this.dialogRef.close();
    }
}
