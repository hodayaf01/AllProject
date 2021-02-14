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
            //this.settingReq.UserId=+(localStorage.getItem('USERCODE'));
            this.PasswordToUser.Password = this.password;
            if(this.password=="1234"){
                this.loggedIn=true;
            }
            else{
                alert("password is incorrect");
            }
            // this.subscribe = this.settingsService.getSettings(this.PasswordToUser).subscribe(
            //     result => {
            //         console.log(result);
            //         if(result==null){
            //             alert("password is incorrect");
            //         }
            //         else{
            //             this.loggedIn=true;
            //             this.userDetails=result;
            //         }
                    
            //     }
            // )
        }

        ngOnInit() {
            this.userDetails = new Settings();
            this.userDetails.user= new User("207420274", "אני עייפה", "hodaya.farkash@gmail.com", "", 2, null);

            this.userDetails.guardians= new Array<Guardian>();
            this.userDetails.guardians[0]= new Guardian(1, "אמא", "0587828027");
            this.userDetails.guardians[1]= new Guardian(2, "אבא", "0587828027");

            this.userDetails.timeOfAlert = new Array<TimeOfDay>();
            this.userDetails.timeOfAlert[0]=new TimeOfDay(1, 1); this.userDetails.timeOfAlert[0].theTime="08:00:00";
            this.userDetails.timeOfAlert[1]=new TimeOfDay(1, 1); this.userDetails.timeOfAlert[1].theTime="08:00:00";
            this.userDetails.timeOfAlert[2]=new TimeOfDay(1, 1); this.userDetails.timeOfAlert[2].theTime="08:00:00";
            this.userDetails.timeOfAlert[3]=new TimeOfDay(1, 1); this.userDetails.timeOfAlert[3].theTime="08:00:00";
        }

        // showUserDetails()
        // {
        //     //this.isUserDetails=false;
        //     //this.isGuardiansDedails=true;
        //     document.getElementById("userDetails").hidden=false;
        //     document.getElementById("guardiansDedails").hidden=true;

        // }

        // showGuardiansDedails()
        // {            
        //     //this.isUserDetails=true;
        //     //this.isGuardiansDedails=false;
        //     document.getElementById("userDetails").hidden=true;
        //     document.getElementById("guardiansDedails").hidden=false;
        // }

        // resetDivs()
        // {

        //     this.isUserDetails=true;
        //     this.isGuardiansDedails=true
        //     this.isTimeOfAlertDetails=true
        // }

        editUser()
        {
            this.subscribe=this.settingsService.edit(this.userDetails)
        }

        ngOnDestroy()
        {
            this.subscribe=null;
        }

    }
    