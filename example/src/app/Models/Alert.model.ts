import { Time } from "@angular/common";

export class User{
    alertText:string;
    alertTime:Time
   
    constructor(text:string,time:Time) {
       this.alertText=text;
       this.alertTime=time;
    }