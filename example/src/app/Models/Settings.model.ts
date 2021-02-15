import {User} from './User.model'
import {Guardian}from './Guardian.model'
import {TimeOfAlertForUser} from './TimeOfAlertForUser.model'
import { TimeOfDay } from './TimeOfDay.model';

export class Settings{
    User:User;
    Guardians:Array<Guardian>=[];
    TimeOfAlert:Array<TimeOfDay>=[];
    
    constructor(u?:User, g?:Array<Guardian>,t?:Array<TimeOfDay>){
        this.User=u;
        this.Guardians=g;
        this.TimeOfAlert=t;
    }
}