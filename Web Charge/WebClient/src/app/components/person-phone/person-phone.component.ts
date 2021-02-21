import { Component, OnInit } from '@angular/core';
import { MatDialog, MatSnackBar } from '@angular/material';
import { PersonModel } from 'src/app/models/person.model';
import { PhoneModel } from 'src/app/models/phone.model';
import { PhoneRequestModel } from 'src/app/models/phone.request.model';
import { PersonServices } from 'src/app/services/person.services';
import { PersonPhoneServices } from 'src/app/services/personPhone.services';
import { InsertAddDialogComponent } from './insert-add-dialog/insert-add-dialog.component';

@Component({
  selector: 'app-person-phone',
  templateUrl: './person-phone.component.html',
  styleUrls: ['./person-phone.component.css']
})
export class PersonPhoneComponent implements OnInit {
  personData: PersonModel;
  snackBarOptions: any = {
    duration: 3000,
    horizontalPosition: 'right',
    verticalPosition: 'top'
  }

  constructor(private personServices: PersonServices,
              private personPhoneServices: PersonPhoneServices,
              public dialog: MatDialog,
              private snackBar: MatSnackBar) { }

  ngOnInit() {
    this.getData();
  }

  newPhoneDialog(){
    let dialogRef = this.dialog.open(InsertAddDialogComponent, {
      data: {
        dialogTitle: "New Phone Number"
      }
    });

    dialogRef.afterClosed().subscribe(
      (data: PhoneModel) => {
        if (data) {
          data.businessEntityID = this.personData.businessEntityID;
          this.saveNewPhone(data);
        }
      }
    )
  }

  editPhoneDialog(phone: PhoneModel){   
    let oldObjKeys: PhoneModel = {
      phoneNumber: phone.phoneNumber,
      phoneNumberTypeID: phone.phoneNumberTypeID,
      businessEntityID: phone.businessEntityID
    }
    
    let dialogRef = this.dialog.open(InsertAddDialogComponent, {
      data: {
        dialogTitle: "Edit Phone Number",
        personPhoneData: phone
      }
    });

    dialogRef.afterClosed().subscribe(
      (data: PhoneModel) => {
        if (data) {
          this.editPhone(data, oldObjKeys);
        }
      }
    )
  }

  getData(){
    this.personServices.getAll().subscribe(
      (resp: any) => {
        this.personData = resp.data.personObjects[0];
      }
    )
  }

  saveNewPhone(phoneData: PhoneModel){
    let phoneRequest: PhoneRequestModel = {
      personPhone: phoneData,
      extra: null
    };

    this.personPhoneServices.newPhone(phoneRequest).subscribe(
      (resp: any) => {
        if (resp.success){
          this.snackBar.open('Phone added successfully', 'X', this.snackBarOptions);
          this.getData();
        }
      }, error => {
        this.snackBar.open('Fail to add new phone number', 'X', this.snackBarOptions);
        console.error(error);
      }
    )
  }

  removePhone(phone: PhoneModel) {
    let phoneRequest: PhoneRequestModel = {
      personPhone: phone,
      extra: null
    }
    
    this.personPhoneServices.removePhone(phoneRequest).subscribe(
      (resp: any) => {
        if (resp.success) {
          this.snackBar.open('Phone removed successfully', 'X', this.snackBarOptions);
          this.getData();
        }
      }, error => {
        this.snackBar.open('Fail to remove phone number', 'X', this.snackBarOptions);
        console.error(error);
      }
    )
  }

  editPhone(phone: PhoneModel, oldObjKeys: PhoneModel) {
    let phoneRequest: PhoneRequestModel = {
      personPhone: phone,
      extra: oldObjKeys
    }

    this.personPhoneServices.editPhone(phoneRequest).subscribe(
      (resp: any) => {
        if (resp.success) {
          this.getData();
        }
      }, error => {
        console.error(error);
      }
    )
  }
}
