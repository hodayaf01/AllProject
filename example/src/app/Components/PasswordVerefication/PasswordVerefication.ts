import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
    selector: 'app-PasswordVerefication',
    templateUrl: './PasswordVerefication.html',
    styleUrls: ['./PasswordVerefication.css']
})
export class PasswordVereficationComponent implements OnInit{
    
    password: string;
    isPawwwordCorrect=true;

    constructor(private router:Router){

    }

    ngOnInit(){

    }

    //check hoe to pass parameters between 2 routing routes
    checkPassword(){
    //     this.isPawwwordCorrect=false;
        
    //     //send again
    // else{
    //     this.router.navigate(['/TimeOfAlert']);
    // }    
    }
}

//