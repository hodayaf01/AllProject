import { User } from './User.model';
import { Guardian } from './Guardian.model';

export class LogIn{
    user:User;
    guardians:Array<Guardian>=[];

    constructor(u?:User, g?:Array<Guardian>){
        this.user=u;
        this.guardians=g;
    }
}