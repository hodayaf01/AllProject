import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/Models/User.model';
import { Guardian } from 'src/app/Models/Guardian.model';
import { RegistrationService } from 'src/app/Services/RegistrationService';
import { Router } from '@angular/router';
import { from } from 'rxjs';
import { Registration } from 'src/app/Models/Registration.model';

@Component({
    selector: 'app-RegistrationUser',
    templateUrl: './RegistrationUser.html',
    styleUrls: ['./RegistrationUser.css']
})

export class RegistrationUserComponent implements OnInit {
    user: User = new User();
    guardian: Guardian = new Guardian();
    registration: Registration = new Registration();
    guardians: Array<Guardian> = [];
    isLessThanThreeGuardian: boolean = false;
    isMoreThanOneGuardian: boolean = true;
    subscribe: any;

    constructor(private registrationService: RegistrationService) {

    }

    sendPassword() {
        var chars = "abcdefghijklmnopqrstuvwxyz!@#$%^&*()-+<>ABCDEFGHIJKLMNOP1234567890";
        var pass = "";
        for (var x = 0; x < length; x++) {
            var i = Math.floor(Math.random() * chars.length);
            pass += chars.charAt(i);
        }
        this.user.password = pass;
    }

    addUser() {

        this.user.Id = 0;
        this.user.userId = "207420274";
        this.user.userName = "הודיה";
        this.user.phone = "0587828027";
        this.user.email = "hodaya.farkash@gmail.com";
        this.user.password = "1234";
        this.user.userHMO = 1;
        this.registration.NewUser = this.user;

        this.guardian.Id = 0;
        this.guardian.PhoneNumber = "0587828027";
        this.guardian.guardianName = "Dady";
        this.guardians.push(this.guardian);
        this.registration.Guardians = this.guardians;



        this.subscribe = this.registrationService.add(this.registration).subscribe(
            result => {
                this.user.Id = result;
                localStorage.setItem('USERCODE', this.user.Id.toString());
                // sessionStorage.setItem('KEY', 'VALUE');
                // var value = sessionStorage.getItem('KEY');
                // sessionStorage.clear('KEY');
                console.log('added'+ this.user.Id);
            }
        );
        
    }

    addGuardian() {
        this.guardian.Id = 0;
        this.guardians.push(this.guardian);
        if (this.guardians.length == 1) {
            this.isMoreThanOneGuardian = false;
        }
        if (this.guardians.length == 3) {
            this.isLessThanThreeGuardian = true;
        }
    }

    ngOnInit() {
    }
}