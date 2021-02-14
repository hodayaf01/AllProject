import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/Models/User.model';
import { Guardian } from 'src/app/Models/Guardian.model';
import { RegistrationService } from 'src/app/Services/RegistrationService';
import { Router } from '@angular/router';
import { from } from 'rxjs';
import { Registration } from 'src/app/Models/Registration.model';
import { MessagingService } from 'src/app/Services/messaging.service';

@Component({
    selector: 'app-Guide',
    templateUrl: './Guide.html',
    styleUrls: ['./Guide.css']
})

export class GuideComponent  {
   

    constructor(private router: Router) {

    }

}