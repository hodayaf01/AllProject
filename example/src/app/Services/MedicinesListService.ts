import {Injectable} from '@angular/core';
import { Observable } from 'rxjs';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import { MedicineToUserByTime } from '../Models/MdicineToUserByTime.model';
import { MedicineToUserByTimeResp } from '../Models/MedicineToUserByTimeResp.model';
import { UpdateMedicineReq } from '../Models/UpdateMedicineList.mode';

const httpOptions ={headers:new HttpHeaders({'Content-type':'application/json'})}

@Injectable()
export class MedicinesListService{

    url='https://localhost:44318/api/MedicinesList'

    constructor(private http:HttpClient) {
                
    }


    get(medicineToUserByTime:MedicineToUserByTime):Observable<any>{
       return this.http.post(`${this.url+'/Get?'}`, medicineToUserByTime, httpOptions);
   }
   update(medicineToUserByTimeResp:UpdateMedicineReq):Observable<any>{
    return this.http.post(`${this.url+'/Update?'}`, medicineToUserByTimeResp, httpOptions);
}

}

   
