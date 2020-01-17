import { User } from './User.model';
import { Guardian } from './Guardian.model';

export class Registration{
    NewUser:User;
    Guardians:Array<Guardian>=[];

    constructor(u?:User, g?:Array<Guardian>){
        this.NewUser=u;
        this.Guardians=g;
    }
}