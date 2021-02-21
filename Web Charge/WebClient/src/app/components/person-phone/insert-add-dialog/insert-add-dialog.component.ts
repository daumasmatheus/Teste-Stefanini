import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { PhoneModel } from 'src/app/models/phone.model';
import { PersonPhoneServices } from 'src/app/services/personPhone.services';

@Component({
  selector: 'app-insert-add-dialog',
  templateUrl: './insert-add-dialog.component.html',
  styleUrls: ['./insert-add-dialog.component.css']
})
export class InsertAddDialogComponent implements OnInit {
  dialogTitle: string;
  editing: boolean = false;

  newPhone: PhoneModel;
  editPhone: PhoneModel;  

  phoneForm: FormGroup;
  
  constructor(@Inject(MAT_DIALOG_DATA) public data: any,
              public dialogRef: MatDialogRef<InsertAddDialogComponent>) { }

  ngOnInit() {
    this.phoneForm = new FormGroup({
      phoneNumber: new FormControl('', [Validators.required]),
      phoneNumberTypeID: new FormControl('', [Validators.required])
    });

    if (this.data){
      this.dialogTitle = this.data.dialogTitle;

      if (this.data.personPhoneData) {
        this.editPhone = this.data.personPhoneData;
        this.phoneForm.patchValue(this.data.personPhoneData);

        this.editing = true;
      }
    }
  }

  compareWith(optOne, optTwo){
    return optOne == optTwo;
  }

  savePhone(){
    if (this.editing) {
      this.editPhone = Object.assign({}, this.editPhone, this.phoneForm.value);
      this.dialogRef.close(this.editPhone);
    } else {
      this.newPhone = Object.assign({}, this.newPhone, this.phoneForm.value);
      this.dialogRef.close(this.newPhone);
    }
  }
}