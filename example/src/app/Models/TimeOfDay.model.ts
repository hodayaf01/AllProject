import { Time } from '@angular/common';

export class TimeOfDay {
    timeId: number;
    timeName: string;
    theTime: Time;

    constructor(id?: number, name?: string, time?: Time) {
        this.timeId = id;
        this.timeName = name;
        this.theTime = time;
    }
}