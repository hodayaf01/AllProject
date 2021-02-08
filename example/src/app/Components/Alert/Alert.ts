import {Component,OnInit} from '@angular/core';
import { Alert } from '../../Models/Alert.model';
import { from } from 'rxjs';
import { ActivatedRoute } from '@angular/router';
@Component({
        selector:'app-Alert',
        templateUrl:'./Alert.html',
        styleUrls:['./Alert.css']
    })
    export class AlertComponent implements OnInit{
        subscribe:any;
        alertTime:Alert;

        constructor(private route:ActivatedRoute){}
       // document.getElementById('txt').innerHTML =
 // h + ":" + m + ":" + s;

    stopAlert()
    {
        
    }

    nagger(){

    }

    ngOnInit() {
this.route.params.subscribe(
    p=>{
       console.log( p.id+" "+p.time)

    }
)
    }


    ngOnDestroy()
    {
        this.subscribe=null;
    }
}