
export class User{
    Id:number;
    childId:string;
    userName:string;
    email:string;
    password:string;
    userHMO:number;
    token: string;
    snoozeCounter:number;
    snoozePeriod:number;
    points:number

    constructor(id?:string,un?:string,em?:string,pas?:string,uHMO?:number, token?:string, snoozeC?:number , snoozeP?:number, p?:number
        ) {
        this.childId=id;
        this.userName=un;
        this.email=em;
        this.password=pas;
        this.userHMO=uHMO;    
        this.token = token;
        this.snoozeCounter=snoozeC;
        this.snoozePeriod=snoozeP;
        this.points=p;
    }
}

