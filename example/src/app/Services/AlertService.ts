import {Injectable} from '@angular/core';
import { Observable, from } from 'rxjs';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import { Alert } from '../Models/Alert.model';
const httpOptions = { headers: new HttpHeaders({ 'Content-type': 'application/json' }) }

@Injectable()
export class AlertService{
    url = 'https://localhost:44318/api/Alert';
    constructor(private http: HttpClient) {

    };

    get(userCode:string):Observable<Alert>{
        return this.http.get<Alert>(`${this.url+'/Get'}`)
    }
}