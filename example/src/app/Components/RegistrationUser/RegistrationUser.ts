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
        if(this.isValidIsraeliID(this.user.childId)==false)
            alert("תעודת זהות אינה בפורמט הנכון") ;
        if(/^[א-ת]+$/.test(this.user.userName)==false)
            alert("שם אמור להכיל אותיות בלבד");
    
        if(this.user.userHMO==0)
            alert("אנא בחר בית חולים");

        else{
            this.addGuardian();
            this.setPassword();
            this.user.token=this.messagingService.token;
            this.registration.NewUser=this.user;
            this.registration.Guardians=this.guardians;
        }       

        this.subscribe = this.registrationService.add(this.registration).subscribe(
                result => {
                    this.user.childId = result.UserId;
                    localStorage.setItem('USERCODE', this.user.childId.toString());
                    localStorage.setItem('PASSWORD', result.Password);
                    this.router.navigate(['/PasswordVerefication']);            
            }
        );
        
    }

    addGuardian() {
        this.guardian.Id += 1;
        this.guardians.push(new Guardian(this.guardian.Id, this.guardian.guardianName, this.guardian.PhoneNumber));

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

    showError(val){
        alert(val + " is incorrect");

    }

    isValidIsraeliID(_id) {
	let id = String(_id).trim();
	if (id.length > 9 || id.length < 5 || isNaN(_id)) return false;

	// Pad string with zeros up to 9 digits
  	id = id.length < 9 ? ("00000000" + id).slice(-9) : id;

      if(Array
            .from(id, Number)
  		    .reduce((counter, digit, i) => {
			    const step = digit * ((i % 2) + 1);
                return counter + (step > 9 ? step - 9 : step);
    	    }) % 10 === 0){
                return true;
            }
            else false;

}
}