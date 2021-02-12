import {Injectable} from '@angular/core';
import { Observable } from 'rxjs';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import { InjectableCompiler } from '@angular/compiler/src/injectable_compiler';
import { ImplicitReceiver } from '@angular/compiler';
import { User } from '../Models/User.model';
import { Registration } from '../Models/Registration.model';
import { SendNewPassword } from '../Models/SendNewPasswordReq.mode';

const httpOptions ={headers:new HttpHeaders({'Content-type':'application/json'})}

@Injectable()
export class RegistrationService{

    url='https://localhost:44318/api/Registration'

    constructor(private http:HttpClient) {
                
    }

    add(Registration:Registration):Observable<any>{
        return this.http.post(`${this.url}/Add`,Registration,httpOptions);
    }

    get(userCode:string):Observable<User>{
        return this.http.get<User>(`${this.url+'/Get?'}`)
    }

    sendNewPassword(userDetail: SendNewPassword):Observable<any>{
        return this.http.post(`${this.url}/SendNewPassword`,userDetail,httpOptions)
    }
}
