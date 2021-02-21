import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { PhoneModel } from '../models/phone.model';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { PhoneRequestModel } from '../models/phone.request.model';

@Injectable({providedIn: 'root'})
export class PersonPhoneServices {
    constructor(private httpClient: HttpClient) { }
    
    newPhone(request: PhoneRequestModel): Observable<any>{
        return this.httpClient.post(environment.apiBaseUrl + 'api/PersonPhone/NewPersonPhone', request);
    }

    removePhone(request: PhoneRequestModel): Observable<any>{
        let httpOpts = {
            headers: new HttpHeaders({'Content-Type': 'application/json'}),
            body: request
        };

        return this.httpClient.delete(environment.apiBaseUrl + `api/PersonPhone/RemovePersonPhone`, httpOpts);
    }

    editPhone(request: PhoneRequestModel): Observable<any>{
        return this.httpClient.patch(environment.apiBaseUrl + 'api/PersonPhone/EditPersonPhone', request);
    }
}