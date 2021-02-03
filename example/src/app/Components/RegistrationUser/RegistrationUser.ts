import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/Models/User.model';
import { Guardian } from 'src/app/Models/Guardian.model';
import { RegistrationService } from 'src/app/Services/RegistrationService';
import { Router } from '@angular/router';
import { from } from 'rxjs';
import { Registration } from 'src/app/Models/Registration.model';
import { MessagingService } from 'src/app/Services/messaging.service';

@Component({
    selector: 'app-RegistrationUser',
    templateUrl: './RegistrationUser.html',
    styleUrls: ['./RegistrationUser.css']
})

export class RegistrationUserComponent implements OnInit {
    guardianId = -1;
    user: User = new User();
    guardian: Guardian = new Guardian();
    registration: Registration = new Registration();
    guardians: Array<Guardian> = [];
    isLessThanThreeGuardian: boolean = false;
    isMoreThanOneGuardian: boolean = true;
    subscribe: any;
    message;

    constructor(private router: Router, 
        private registrationService: RegistrationService, 
        private messagingService: MessagingService) {

    }

    setPassword() {
        var chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOP1234567890";
        var pass = "";
        for (var x = 0; x < 4; x++) {
            var i = Math.floor(Math.random() * chars.length);
            pass += chars.charAt(i);
        }
        this.user.password = pass;
    }

    addUser() {
        //validations: 
        if(this.user.userHMO==0)
            alert("אנא בחר בית חולים");
        else{
            this.setPassword();
            this.user.token=this.messagingService.token;
            this.registration.NewUser=this.user;
            this.registration.Guardians=this.guardians;
        }
        console.log(this.registration);
       

        this.subscribe = this.registrationService.add(this.registration).subscribe(
            result => {
                this.user.childId = result;
                localStorage.setItem('USERCODE', this.user.childId.toString());
                // sessionStorage.setItem('KEY', 'VALUE');
                // var value = sessionStorage.getItem('KEY');
                // sessionStorage.clear('KEY');
                console.log('added'+ this.user.childId);
                this.router.navigate(['/TimeOfAlert']);
            }
        );
        
    }

    addGuardian() {
        this.guardian.Id += 1;
        this.guardians.push(this.guardian);

        if (this.guardians.length == 1) {
            this.isMoreThanOneGuardian = false;
        }
        if (this.guardians.length == 3) {
            this.isLessThanThreeGuardian = true;
        }
        this.guardian.guardianName="";
        this.guardian.PhoneNumber="";
    }

    ngOnInit() {
        this.user.userHMO=0;
        this.messagingService.requestPermission()
        this.messagingService.receiveMessage()
        this.message = this.messagingService.currentMessage;
    }
}