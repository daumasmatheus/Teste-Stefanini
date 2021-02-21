import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({providedIn: 'root'})
export class PersonServices {
    constructor(private httpClient: HttpClient) { }
    
    getAll(): Observable<any>{
        return this.httpClient.get(environment.apiBaseUrl + `api/Person/GetAll`)
    }    
}