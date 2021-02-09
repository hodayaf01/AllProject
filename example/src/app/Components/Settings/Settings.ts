import {Component,OnInit} from '@angular/core';
import { SettingsService } from '../../Services/SettingsService';
import { Settings } from '../../Models/Settings.model';
import { SettingsReq } from 'src/app/Models/settingsReq.model';
@Component({
        selector:'app-Settings',
        templateUrl:'./Settings.html',
        styleUrls:['./Settings.css']
    })
    export class SettingsComponent implements OnInit {
        userDetails:Settings;
        password:string;
        settingReq:SettingsReq;
        loggedIn:boolean = false;
        subscribe:any;

        isUserDetails:boolean=true;
        isGuardiansDedails:boolean=true;
        isTimeOfAlertDetails:boolean=false;

        constructor(private settingsService: SettingsService){
          
        }

        checkPasswordAndretriveSettings(){
            this.settingReq.UserId=+(localStorage.getItem('USERCODE'));
            this.settingReq.Password = this.password;
            this.subscribe = this.settingsService.get(this.settingReq).subscribe(
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

        showUserDetails()
        {
            //this.isUserDetails=false;
            //this.isGuardiansDedails=true;
            document.getElementById("userDetails").hidden=false;
            document.getElementById("guardiansDedails").hidden=true;

        }

        showGuardiansDedails()
        {            
            //this.isUserDetails=true;
            //this.isGuardiansDedails=false;
            document.getElementById("userDetails").hidden=true;
            document.getElementById("guardiansDedails").hidden=false;
        }

        resetDivs()
        {

            this.isUserDetails=true;
            this.isGuardiansDedails=true
            this.isTimeOfAlertDetails=true
        }

        editUser()
        {
            this.subscribe=this.settingsService.edit(this.userDetails)
        }

        ngOnInit() {
            
        }

        ngOnDestroy()
        {
        this.subscribe=null;
        }
       
        addOrEdit()
        {
          //this.detailsUser.addOrEdit(this.user);
         
        }
    }
    