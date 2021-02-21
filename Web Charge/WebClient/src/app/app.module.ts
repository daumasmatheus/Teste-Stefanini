import { BrowserModule } from '@angular/platform-browser';
import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatTableModule } from '@angular/material/table';
import { MatButtonModule, MatCardModule, MatDialogModule, matFormFieldAnimations, MatFormFieldModule, MatIconModule, MatInputModule, MatListModule, MatSelectModule, MatSnackBarModule, MatTooltipModule } from '@angular/material';

import { AppComponent } from './app.component';
import { PersonServices } from './services/person.services';
import { PersonPhoneComponent } from './components/person-phone/person-phone.component';
import { InsertAddDialogComponent } from './components/person-phone/insert-add-dialog/insert-add-dialog.component';
import { FlexLayoutModule } from '@angular/flex-layout';
import { NgxMaskModule } from 'ngx-mask';
import { PersonPhoneServices } from './services/personPhone.services';

@NgModule({
  declarations: [
    AppComponent,
    PersonPhoneComponent,
    InsertAddDialogComponent    
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    FlexLayoutModule,
    NgxMaskModule.forRoot(),      
    MatListModule,
    MatIconModule,
    MatCardModule,
    MatTableModule,
    MatSnackBarModule,
    MatDialogModule,
    MatSelectModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatTooltipModule
  ],
  providers: [
    PersonServices,
    PersonPhoneServices
  ],
  bootstrap: [AppComponent],
  entryComponents: [InsertAddDialogComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class AppModule { }
