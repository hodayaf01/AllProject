import { Snoozer } from './Snoozer.model';
import { TimeOfDay } from './TimeOfDay.model';

export class TimeOfAlertForUser{
    snoose:Snoozer;
    timeOfDay:Array<TimeOfDay>=[];

    constructor(sno?:Snoozer, time?:Array<TimeOfDay>){
        this.snoose=sno;
        this.timeOfDay=time;

    }
}