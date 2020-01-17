import {User} from './User.model'
import {Guardian}from './Guardian.model'
import {TimeOfAlertForUser} from './TimeOfAlertForUser.model'

export class Settings{
    user:User;
    guardians:Array<Guardian>=[];
    timeOfAlert:Array<TimeOfAlertForUser>=[];
    
    constructor(u?:User, g?:Array<Guardian>,t?:Array<TimeOfAlertForUser>){
        this.user=u;
        this.guardians=g;
        this.timeOfAlert=t;
    }
}