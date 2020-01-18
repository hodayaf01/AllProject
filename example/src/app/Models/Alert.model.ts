import { Time } from "@angular/common";

export class Alert{
    alertText:string;
    alertTime:Time
   
    constructor(text:string,time:Time) {
       this.alertText=text;
       this.alertTime=time;
    }