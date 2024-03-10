import {ComponentFixture, TestBed} from '@angular/core/testing';
import {MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import {ConfirmationDialogMaterialComponent} from './confirmation-dialog-material.component';

describe('ConfirmationDialogMaterialComponent', () => {
  let component: ConfirmationDialogMaterialComponent;
  let fixture: ComponentFixture<ConfirmationDialogMaterialComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ConfirmationDialogMaterialComponent],
      providers: [
        {
          provide: MatDialogRef,
          useValue: {
            close: jasmine.createSpy('close'),
          },
        },
        {
          provide: MAT_DIALOG_DATA,
          useValue: {},
        },
      ],
    });

    fixture = TestBed.createComponent(ConfirmationDialogMaterialComponent);
    component = fixture.componentInstance;
  });

  it('Should create the component', () => {
    expect(component).toBeTruthy();
  });

  it('Should close with false on "No" click', () => {
    component.onNoClick();

    const matDialogRef = TestBed.inject(MatDialogRef);
    expect(matDialogRef.close).toHaveBeenCalledWith(false);
  });

  it('Should close with true on "Yes" click', () => {
    component.onYesClick();

    const matDialogRef = TestBed.inject(MatDialogRef);
    expect(matDialogRef.close).toHaveBeenCalledWith(true);
  });
});
