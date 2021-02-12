export class SendNewPassword{
    UserCode:string;
    Email:string;
    Password:string;

    constructor(u?:string, e?:string, p?:string){
        this.UserCode=u;
        this.Email=e;
        this.Password=p;
    }
}