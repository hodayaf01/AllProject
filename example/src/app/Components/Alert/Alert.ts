import {Component,OnInit} from '@angular/core';
import { Alert } from '../../Models/Alert.model';
import { from } from 'rxjs';
@Component({
        selector:'app-Alert',
        templateUrl:'./Alert.html',
        styleUrls:['./Alert.css']
    })
    export class AlertComponent implements OnInit{
        subscribe:any;
        alertTime:Alert;

        constructor(){}
       // document.getElementById('txt').innerHTML =
 // h + ":" + m + ":" + s;

    stopAlert()
    {
        
    }

    nagger(){

    }

    ngOnInit() {}


    ngOnDestroy()
    {
        this.subscribe=null;
    }
}