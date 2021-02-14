import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { SendNewPassword } from 'src/app/Models/SendNewPasswordReq.mode';
import { RegistrationService } from 'src/app/Services/RegistrationService';

@Component({
    selector: 'app-PasswordVerefication',
    templateUrl: './PasswordVerefication.html',
    styleUrls: ['./PasswordVerefication.css']
})
export class PasswordVereficationComponent implements OnInit{
    
    password: string;
    newPassword: string;
    email: string;
    isPawwwordCorrect=true;
    tryAgain: boolean = false;
    isChoosePass: boolean = false;
    subscriber: any;

    constructor(private router:Router, 
        private registrarionService: RegistrationService){

    }

    ngOnInit(){

    }

    validatePassword(){
        //if(this.password=='1234'){
        if(this.password==localStorage.getItem('PASSWORD')){
            this.router.navigate(['/TimeOfAlert']);
        }
        else{
            this.tryAgain=true;
             this.isPawwwordCorrect=false;
        }
    }

    tryAgainF(){
        this.password='';
        this.tryAgain=false;
        this.isPawwwordCorrect=true;
    }

    resendPassword(){
        this.tryAgain==true;
        this.isPawwwordCorrect=true;
        this.password='';
        this.isChoosePass=true;
        var chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOP1234567890";
        var pass = "";
        for (var x = 0; x < 4; x++) {
            var i = Math.floor(Math.random() * chars.length);
            pass += chars.charAt(i);
        }
        this.newPassword=pass;
        
    }

    submitNewPassword(){
        this.isChoosePass=false;
        this.tryAgain=false;

        let userDetail: SendNewPassword = new SendNewPassword();
        //userDetail.UserCode = 30010; 
        localStorage.getItem('USERCODE');
        userDetail.Email=this.email;
        userDetail.Password=this.newPassword;

        this.subscriber = this.registrarionService.sendNewPassword(userDetail).subscribe(
            response => {
                localStorage.setItem('PASSWORD', response.Password);
            }
        );


    }
}