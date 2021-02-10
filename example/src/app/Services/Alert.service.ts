import {Injectable} from '@angular/core';
import { Observable } from 'rxjs';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import { InjectableCompiler } from '@angular/compiler/src/injectable_compiler';
import { ImplicitReceiver } from '@angular/compiler';
import { MedicineToUserByTime } from '../Models/MdicineToUserByTime.model';

const httpOptions ={headers:new HttpHeaders({'Content-type':'application/json'})}

@Injectable()
export class AlertService{

    url='https://localhost:44318/api/Alert'

    constructor(private http:HttpClient) {
                
    }

    cancleAlertAndNavigate(timeForUser:MedicineToUserByTime):Observable<any>{
        return this.http.post(`${this.url}/X`,timeForUser,httpOptions);
    }

}
