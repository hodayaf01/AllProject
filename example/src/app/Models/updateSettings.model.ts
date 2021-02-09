import { installations } from "firebase";

export class Settings{
    UserId:number;
    Password:string;
    
    constructor(u?:number, p?:string){
        this.UserId=u;
        this.Password=p;
    }
}