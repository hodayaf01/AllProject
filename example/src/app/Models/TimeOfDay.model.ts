import { Time } from '@angular/common';

export class TimeOfDay {
    timeId: number;
    timeCode: number;
    theTime: string;

    constructor(id?: number, code?: number) {
        this.timeId = id;
        this.timeCode = code;
       // this.theTime = {hours:0,minutes:0};
    }
}