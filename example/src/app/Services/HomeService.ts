import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import {HttpClient, HttpHeaders } from '@angular/common/http';
import { MedicineToUserByTime } from '../Models/MdicineToUserByTime.model';

//const httpOptions ={headers:new HttpHeaders({'Content-type':'application/json'})}

@Injectable()
export class HomeService{
    url='https://localhost:44318/api/Home'

    constructor(private http:HttpClient){

    }

    get(timeOfDay:number):Observable<MedicineToUserByTime>{
        return this.http.get<MedicineToUserByTime> (`${this.url}/Get`);
    }
}