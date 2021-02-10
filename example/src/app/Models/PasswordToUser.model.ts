

export class PasswordToUser{
    UserId: number;
    Password: string;
    
    constructor(u?:number, p?:string){
        this.UserId=u;
        this.Password=p;
    }
}