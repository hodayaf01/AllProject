import { Time } from "@angular/common";

export class Alert{
   textAlert:string;
   timeAlert:Time
   
    constructor(text:string,time:Time) {
       this.textAlert=text;
       this.timeAlert=time;
    }
   }