import {Injectable} from '@angular/core';
import { Observable } from 'rxjs';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import { InjectableCompiler } from '@angular/compiler/src/injectable_compiler';
import { ImplicitReceiver } from '@angular/compiler';
import { User } from '../Models/User.model';
import { LogIn } from '../Models/LogIn.model';


const httpOptions ={headers:new HttpHeaders({'Content-type':'application/json'})}

@Injectable()
export class UserService{

    url='https://localhost:44318/api/Registration'

    constructor(private http:HttpClient) {
                
    }

    add(Registration:LogIn):Observable<any>{
        return this.http.post(`${this.url}/Add`,Registration,httpOptions);
    }


}
