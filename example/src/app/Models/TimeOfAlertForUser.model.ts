import { Snoozer } from './Snoozer.model';
import { TimeOfDay } from './TimeOfDay.model';

export class TimeOfAlertForUser{
    snooze:Snoozer;
    timeOfDay:Array<TimeOfDay>=[];

    constructor(sno?:Snoozer, time?:Array<TimeOfDay>){
        this.snooze=sno;
        this.timeOfDay=time;

    }
}