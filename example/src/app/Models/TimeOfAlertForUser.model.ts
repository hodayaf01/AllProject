import { TimeOfDay } from './TimeOfDay.model';

export class TimeOfAlertForUser{
    userId:number;
    timeOfDay:Array<TimeOfDay>=[];

    constructor(id?:number, time?:Array<TimeOfDay>){
        this.userId=id;
        this.timeOfDay=time;
    }
}