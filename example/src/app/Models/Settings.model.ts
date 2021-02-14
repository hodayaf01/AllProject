import {User} from './User.model'
import {Guardian}from './Guardian.model'
import {TimeOfAlertForUser} from './TimeOfAlertForUser.model'
import { TimeOfDay } from './TimeOfDay.model';

export class Settings{
    user:User;
    guardians:Array<Guardian>=[];
    timeOfAlert:Array<TimeOfDay>=[];
    
    constructor(u?:User, g?:Array<Guardian>,t?:Array<TimeOfDay>){
        this.user=u;
        this.guardians=g;
        this.timeOfAlert=t;
    }
}