
import { Component, OnInit } from '@angular/core';
import { AlertService } from 'src/app/Services/Alert.service';

@Component({
    selector: 'app-Portal',
    templateUrl: './Portal.html',
    styleUrls: ['./Portal.css']
})

export class PortalComponent implements OnInit{

    subscribe: any;
    
    constructor(private alertService: AlertService){}
    
    ngOnInit(){
        // this.subscribe = this.alertService.getMedicineByName().subscribe(
        //     res =>{
        //         console.log(res);
        //     }
        // )
    }

}