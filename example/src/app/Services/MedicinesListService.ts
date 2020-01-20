import {Injectable} from '@angular/core';
import { Observable } from 'rxjs';
import {HttpClient, HttpHeaders} from '@angular/common/http';

const httpOptions ={headers:new HttpHeaders({'Content-type':'application/json'})}

@Injectable()
export class MedicinesListService{

    url='https://localhost:44318/api/MedicinesList'

    constructor(private http:HttpClient) {
                
    }

    //add(MedicinesList:MedicinesList):Observable<any>{
    //   return this.http.post(`${this.url}/Add`,MedicinesList,httpOptions);
    //}

    //get(userCode:string):Observable<User>{
    //    return this.http.get<User>(`${this.url+'/Get?'}`)
   // }


}

   
