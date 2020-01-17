import { Time } from '@angular/common';

export class TimeOfDay {
    timeId: number;
    timeCode: number;
    theTime: Time;

    constructor(id?: number, code?: number, time?: Time) {
        this.timeId = id;
        this.timeCode = code;
        this.theTime = time;
    }
}