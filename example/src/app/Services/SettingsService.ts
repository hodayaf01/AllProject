import {Injectable} from '@angular/core';
import { Observable } from 'rxjs';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import { InjectableCompiler } from '@angular/compiler/src/injectable_compiler';
import { ImplicitReceiver } from '@angular/compiler';
import { Settings } from '../Models/Settings.model';
import { PasswordToUser } from '../Models/PasswordToUser.model';

const httpOptions = { headers: new HttpHeaders({ 'Content-type': 'application/json' }) }

@Injectable()
export class SettingsService{
    url = 'https://localhost:44318/api/Settings';
    constructor(private http: HttpClient) {

    };

    getSettings(PasswordToUser:PasswordToUser):Observable<any>{
        return this.http.post(`${this.url}/Get`, PasswordToUser, httpOptions);
    }

    edit(s: Settings): Observable<any> {
        return this.http.post(`${this.url}/Edit`, s, httpOptions);
       // this.http.post<void>(`${_url}`,JSON.stringify(d),httpOptions).subscribe(s=>{});
    }
}