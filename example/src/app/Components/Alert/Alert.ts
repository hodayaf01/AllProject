import {Component,OnInit} from '@angular/core';
import { Alert } from '../../Models/Alert.model';
import { from } from 'rxjs';
import { ActivatedRoute, Router } from '@angular/router';
import { AlertService } from 'src/app/Services/Alert.service';
import { TimeOfAlertForUser } from 'src/app/Models/TimeOfAlertForUser.model';
import { MedicineToUserByTime } from 'src/app/Models/MdicineToUserByTime.model';
@Component({
        selector:'app-Alert',
        templateUrl:'./Alert.html',
        styleUrls:['./Alert.css']
    })
    export class AlertComponent implements OnInit{
        subscribe:any;
        alertTime:Alert;
        timeForUser: MedicineToUserByTime = new MedicineToUserByTime();
        timeCode:number;

        constructor(private route:ActivatedRoute,
            private router: Router,
            private alertService:AlertService){

        }

        cancleAlertAndNvigateToList(){
           this.timeForUser.UserID=+(localStorage.getItem('USERCODE'));

           this.timeForUser.TimeOfDay=this.timeCode;
            this.subscribe = this.alertService.cancleAlertAndNavigate(this.timeForUser).subscribe(
                result => {
                    localStorage.setItem('SNOOZECOUNETR', result);
                   
                    this.router.navigate(['/MedicinesList']);
                }
            );
        }

    ngOnInit() {
        this.route.params.subscribe(
            p=>{
                this.timeCode=p.time; //this.timeCode = 4;
                localStorage.setItem('TIMEOFALERT',p.time);
            })
    }

    close(){
        this.router.navigate(['/Home']);
    }
}