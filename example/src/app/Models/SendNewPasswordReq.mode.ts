export class SendNewPassword{
    UserCode:number;
    Email:string;
    Password:string;

    constructor(u?:number, e?:string, p?:string){
        this.UserCode=u;
        this.Email=e;
        this.Password=p;
    }
}