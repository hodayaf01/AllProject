import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { TimeOfAlertForUser } from '../Models/TimeOfAlertForUser.model';
import { Observable } from 'rxjs';

const httpOptions = { headers: new HttpHeaders({ 'Content-type': 'application/json' }) }

@Injectable()
export class TimeOfAlertForUserService {
    url = 'https://localhost:44318/api/TimeOfAlert';
    constructor(private http: HttpClient) {

    };

    add(t: TimeOfAlertForUser): Observable<any> {
        return this.http.post(`${this.url}/Add`, t, httpOptions);
    }

}