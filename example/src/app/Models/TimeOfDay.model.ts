import { Time } from '@angular/common';

export class TimeOfDay {
    timeId: number;
    timeCode: number;
    theTime: Date = new Date();

    constructor(id?: number, code?: number, time?: Date) {
        this.timeId = id;
        this.timeCode = code;
        this.theTime = time;
    }
}