
export class Snoozer{

    userId:number;
    snoozeCounter: number;
    snoozePeriod: number;


    constructor(id?:number,snoozeCounter?:number, snoozePeriod?:number) {
        this.userId=id;
        this.snoozeCounter=snoozeCounter;
        this.snoozePeriod=snoozePeriod;
    }
}