import {Component,OnInit} from '@angular/core';
import { Alert } from '../../Models/Alert.model';
import {AlertService} from '../../Services/AlertService'
import { from } from 'rxjs';
@Component({
        selector:'app-Alert',
        templateUrl:'./Alert.html',
        styleUrls:['./Alert.css']
    })
    export class AlertComponent implements OnInit{
        subscribe:any;
        alertTime:Alert;

        constructor(private settingsService: AlertService){}
       // document.getElementById('txt').innerHTML =
 // h + ":" + m + ":" + s;

    ngOnInit() {}


    ngOnDestroy()
    {
        this.subscribe=null;
    }
}