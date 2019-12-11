import { OnInit, Component } from '@angular/core';
import { TimeOfAlertForUser } from 'src/app/Models/TimeOfAlertForUser.model';
import { TimeOfDay } from 'src/app/Models/TimeOfDay.model';
import { TimeOfAlertForUserService } from 'src/app/Services/TimeOfDayForUser.service';


@Component({
    selector: 'app-TimeOfAlert',
    templateUrl: './TimeOfAlert.html',
    styleUrls: ['./TimeOfAlert.css']
})

export class TimeOfAlertComponent implements OnInit {

    timeOfAlertForUser: TimeOfAlertForUser = new TimeOfAlertForUser();
    timeOfDay: TimeOfDay = new TimeOfDay();
    timeOfDays: Array<TimeOfDay>= [];
    subscribe: any;

    constructor(private timeOfAlertForUserService: TimeOfAlertForUserService) { }
    ngOnInit() {
        console.log("alert page");
    }

    setTimeInDay() {
        this.timeOfAlertForUser.userId = parseInt(localStorage.getItem('USERCODE'));
        this.timeOfDay.timeId=1; this.timeOfDay.timeName="morning"; this.timeOfDay.theTime.hours=8; this.timeOfDay.theTime.minutes=0;
        this.timeOfDays.push(this.timeOfDay);
        this.timeOfDay.timeId=2; this.timeOfDay.timeName="noon"; this.timeOfDay.theTime.hours=13; this.timeOfDay.theTime.minutes=0;
        this.timeOfDays.push(this.timeOfDay);
        this.timeOfDay.timeId=3; this.timeOfDay.timeName="evening"; this.timeOfDay.theTime.hours=18; this.timeOfDay.theTime.minutes=0;
        this.timeOfDays.push(this.timeOfDay);
        this.timeOfDay.timeId=4; this.timeOfDay.timeName="night"; this.timeOfDay.theTime.hours=21; this.timeOfDay.theTime.minutes=0;
        this.timeOfDays.push(this.timeOfDay);


        this.subscribe= this.timeOfAlertForUserService.add(this.timeOfAlertForUser).subscribe(
            result => {
                console.log(result);
            }
        );
    }
}