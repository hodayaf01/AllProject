import {Injectable} from '@angular/core';
import { Observable } from 'rxjs';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import { MedicineToUserByTime } from '../Models/MdicineToUserByTime.model';

const httpOptions ={headers:new HttpHeaders({'Content-type':'application/json'})}

@Injectable()
export class MedicinesListService{

    url='https://localhost:44318/api/MedicinesList'

    constructor(private http:HttpClient) {
                
    }


    get(medicineToUserByTime:MedicineToUserByTime):Observable<any>{
       return this.http.post(`${this.url+'/Get?'}`, medicineToUserByTime, httpOptions);
   }
   update(userCode:MedicineToUserByTime):Observable<MedicineToUserByTime>{
    return this.http.get<MedicineToUserByTime>(`${this.url+'/Update?'}`)
}

}

   
