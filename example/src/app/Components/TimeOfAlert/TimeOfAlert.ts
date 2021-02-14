import { OnInit, Component } from '@angular/core';
import { Snoozer } from 'src/app/Models/Snoozer.model';
import { TimeOfAlertForUser } from 'src/app/Models/TimeOfAlertForUser.model';
import { TimeOfDay } from 'src/app/Models/TimeOfDay.model';
import { TimeOfAlertForUserService } from 'src/app/Services/TimeOfAlert.service';
import { Router } from '@angular/router';
import { Time } from '@angular/common';

@Component({
    selector: 'app-TimeOfAlert',
    templateUrl: './TimeOfAlert.html',
    styleUrls: ['./TimeOfAlert.css']
})

export class TimeOfAlertComponent implements OnInit {
    snooze: Snoozer = new Snoozer();
    timeOfDay: TimeOfDay = new TimeOfDay();
    timeOfAlertForUser: TimeOfAlertForUser = new TimeOfAlertForUser();
    
    morningTime:string;
    noonTome: string;
    evening:string;
    night:string;
    
    subscribe: any;

    date:Date = new Date();

    constructor(private router: Router, 
                private timeOfAlertForUserService: TimeOfAlertForUserService) {
            this.date.setHours(12);
            this.date.toUTCString();
        }
    
    ngOnInit() {
        this.snooze.snoozeCounter=0;
        this.snooze.snoozePeriod=0;
    }

    setTimeInDay() {
        
        // this.snooze.userId= parseInt(localStorage.getItem('USERCODE'));
        this.snooze.userId=30010;
        //this.timeOfDay.timeCode=1; this.timeOfDay.theTime.setHours(+this.morningTime.split(':')[0]); this.timeOfDay.theTime.setMinutes(+this.morningTime.split(':')[1]);
        this.timeOfDay = new TimeOfDay();
        this.timeOfDay.timeCode=1; 
        this.timeOfDay.theTime=this.morningTime.toString();
        this.timeOfAlertForUser.timeOfDay = new Array<TimeOfDay>();
        this.timeOfAlertForUser.timeOfDay[0]= new TimeOfDay();
        this.timeOfAlertForUser.timeOfDay[0]= this.timeOfDay;


        this.timeOfDay = new TimeOfDay();
        this.timeOfDay.timeCode=2; 
        this.timeOfDay.theTime=this.noonTome;

        this.timeOfAlertForUser.timeOfDay[1]= new TimeOfDay();
        this.timeOfAlertForUser.timeOfDay[1]= this.timeOfDay;

        this.timeOfDay = new TimeOfDay();
        this.timeOfDay.timeCode=3; 
        this.timeOfDay.theTime=this.evening;
        this.timeOfAlertForUser.timeOfDay[2]= new TimeOfDay();
        this.timeOfAlertForUser.timeOfDay[2]= this.timeOfDay;

        this.timeOfDay = new TimeOfDay();
        this.timeOfDay.timeCode=4; 
        this.timeOfDay.theTime=this.night;
        this.timeOfAlertForUser.timeOfDay[3]= new TimeOfDay();
        this.timeOfAlertForUser.timeOfDay[3]= this.timeOfDay;

        this.timeOfAlertForUser.snooze = new Snoozer();
        this.timeOfAlertForUser.snooze=this.snooze;
        
        this.subscribe= this.timeOfAlertForUserService.add(this.timeOfAlertForUser).subscribe(
            result => {

                console.log(result);
                this.router.navigate(['/Home']);
            }
        );
    }
}