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


    get(userCode:string):Observable<MedicineToUserByTime>{
       return this.http.get<MedicineToUserByTime>(`${this.url+'/Get?'}`)
   }
   update(userCode:string):Observable<MedicineToUserByTime>{
    return this.http.get<MedicineToUserByTime>(`${this.url+'/Update?'}`)
}

}

   
