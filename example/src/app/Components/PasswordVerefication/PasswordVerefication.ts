import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
    selector: 'app-PasswordVerefication',
    templateUrl: './PasswordVerefication.html',
    styleUrls: ['./PasswordVerefication.css']
})
export class PasswordVereficationComponent implements OnInit{
    
    password: string;
    email: string;
    isPawwwordCorrect=true;
    tryAgain: boolean = false;
    isChoosePass: boolean = false;

    constructor(private router:Router){

    }

    ngOnInit(){

    }

    validatePassword(){
        if(this.password=='1234'){
        //if(this.password==localStorage.getItem('PASSWORD')){
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

    //chck if need to use this function 
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
        
    }

    submitNewPassword(){
        this.isChoosePass=false;
        this.tryAgain=false;
    }
}