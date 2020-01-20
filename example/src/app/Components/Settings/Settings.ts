import {Component,OnInit} from '@angular/core';
import { SettingsService } from '../../Services/SettingsService';
import { Settings } from '../../Models/Settings.model';
@Component({
        selector:'app-Settings',
        templateUrl:'./Settings.html',
        styleUrls:['./Settings.css']
    })
    export class SettingsComponent implements OnInit {
        userDetails:Settings;
        password:string;
        subscribe:any;
        isSettings:boolean=true;
        isUserDetails:boolean=true;
        isGuardiansDedails:boolean=true;
        isTimeOfAlertDetails:boolean=false;

        constructor(private settingsService: SettingsService){
           /* this.subscribe=this.settingsService.get(localStorage.getItem('USERCODE')).subscribe(result=>
                {this.userDetails=result});*/
            this.subscribe=this.settingsService.get("3").subscribe(result=>
            {this.userDetails=result});
           
        }
        checkPassword()
        {    
            this.isSettings=false;
            //document.getElementById("userDetails").setAttribute("hidden",this.isUserDetails.toString());   
            //document.getElementById("settingsForm").setAttribute("hidden","false") ;
            document.getElementById("settingsForm").hidden=false;
            if(this.userDetails.user.password===this.password)
            {
                

            }
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
    