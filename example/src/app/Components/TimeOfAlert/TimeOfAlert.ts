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
    
    morningTime: string;
    noonTome: string;
    evening:string;
    night:string;
    
    subscribe: any;

    constructor(
        private router: Router, 
        private timeOfAlertForUserService: TimeOfAlertForUserService) { }
    ngOnInit() {
        this.snooze.snoozeCounter=0;
        this.snooze.snoozePeriod=0;
    }

    setTimeInDay() {
        
        this.snooze.userId= parseInt(localStorage.getItem('USERCODE'));

        //this.timeOfDay.timeCode=1; this.timeOfDay.theTime.setHours(+this.morningTime.split(':')[0]); this.timeOfDay.theTime.setMinutes(+this.morningTime.split(':')[1]);
        this.timeOfDay.timeCode=1; this.timeOfDay.theTime.setHours(8); this.timeOfDay.theTime.setMinutes(0);
        console.log(this.timeOfDay);
        this.timeOfAlertForUser.timeOfDay.push(this.timeOfDay);
        this.timeOfDay.timeCode=2; this.timeOfDay.theTime.setHours(13); this.timeOfDay.theTime.setMinutes(0);
        this.timeOfAlertForUser.timeOfDay.push(this.timeOfDay);
        this.timeOfDay.timeCode=3; this.timeOfDay.theTime.setHours(18); this.timeOfDay.theTime.setMinutes(0);
        this.timeOfAlertForUser.timeOfDay.push(this.timeOfDay);
        this.timeOfDay.timeCode=4; this.timeOfDay.theTime.setHours(20); this.timeOfDay.theTime.setMinutes(0);
        this.timeOfAlertForUser.timeOfDay.push(this.timeOfDay);

        
        this.subscribe= this.timeOfAlertForUserService.add(this.timeOfAlertForUser).subscribe(
            result => {
                console.log(result);
                this.router.navigate(['/Home']);
            }
        );
    }
}