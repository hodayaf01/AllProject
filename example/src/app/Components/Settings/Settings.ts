import {Component,OnInit} from '@angular/core';
import { SettingsService } from '../../Services/SettingsService';
import { Settings } from '../../Models/Settings.model';
import { PasswordToUser } from 'src/app/Models/PasswordToUser.model';
import { User } from 'src/app/Models/User.model';
import { Guardian } from 'src/app/Models/Guardian.model';
import { TimeOfAlertForUser } from 'src/app/Models/TimeOfAlertForUser.model';
import { Snoozer } from 'src/app/Models/Snoozer.model';
import { TimeOfDay } from 'src/app/Models/TimeOfDay.model';
@Component({
        selector:'app-Settings',
        templateUrl:'./Settings.html',
        styleUrls:['./Settings.css']
    })
    export class SettingsComponent implements OnInit {
        userDetails:Settings;
        password:string;
        PasswordToUser:PasswordToUser;
        loggedIn:boolean = false;
        subscribe:any;

        isUserDetails:boolean=true;
        isGuardiansDedails:boolean=true;
        isTimeOfAlertDetails:boolean=false;

        constructor(private settingsService: SettingsService){
          
        }

        checkPasswordAndretriveSettings(){

            this.PasswordToUser=new PasswordToUser();
            this.PasswordToUser.UserId=30010;
            this.PasswordToUser.Password = this.password;
            // //if(this.password=="1234"){
            this.subscribe = this.settingsService.getSettings(this.PasswordToUser).subscribe(
                result => {
                    console.log(result);
                    if(result==null){
                        alert("password is incorrect");
                    }
                    else{
                        this.loggedIn=true;
                        this.userDetails=result;
                    }
                    
                }
            )
       
        }

        ngOnInit() {
            this.userDetails = new Settings();
            this.userDetails.User= new User("207420274", "אני עייפה", "hodaya.farkash@gmail.com", "", 2, null, 2, 5);

            this.userDetails.Guardians= new Array<Guardian>();
            this.userDetails.Guardians[0]= new Guardian(1, "אמא", "0587828027");
            this.userDetails.Guardians[1]= new Guardian(2, "אבא", "0587828027");

            this.userDetails.TimeOfAlert = new Array<TimeOfDay>();
            this.userDetails.TimeOfAlert[0]=new TimeOfDay(1, 1); this.userDetails.TimeOfAlert[0].theTime="08:00:00";
            this.userDetails.TimeOfAlert[1]=new TimeOfDay(1, 1); this.userDetails.TimeOfAlert[1].theTime="08:00:00";
            this.userDetails.TimeOfAlert[2]=new TimeOfDay(1, 1); this.userDetails.TimeOfAlert[2].theTime="08:00:00";
            this.userDetails.TimeOfAlert[3]=new TimeOfDay(1, 1); this.userDetails.TimeOfAlert[3].theTime="08:00:00";
        }


        editUser()
        {
            this.subscribe=this.settingsService.edit(this.userDetails).subscribe(
                result =>{
                    alert("updated");
                }
            )
        }

        addGuardian(){
            if(this.userDetails.Guardians.length==3){
                alert("מספר האפוטרופוסים מוגבל ל-3");
            }
            else{
                this.userDetails.Guardians.push(new Guardian(null, "",""));
            }
        }

        removeGuardian(){
            if(this.userDetails.Guardians.length==1){
                alert("מינימום אפוטרופוסים עומד על 1");
            }
            else{
                this.userDetails.Guardians.pop();
            }
        }

    }
    