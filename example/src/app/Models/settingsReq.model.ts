

export class SettingsReq{
    UserId: number;
    Password: string;
    
    constructor(u?:number, p?:string){
        this.UserId=u;
        this.Password=p;
    }
}