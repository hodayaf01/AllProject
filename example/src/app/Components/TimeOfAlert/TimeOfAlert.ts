import { OnInit, Component } from '@angular/core';


@Component({
    selector: 'app-TimeOfAlert',
    templateUrl: './TimeOfAlert.html',
    styleUrls: ['./TimeOfAlert.css']
})

export class TimeOfAlertComponent implements OnInit {

    constructor(){}
    ngOnInit() {
        console.log("alert page");
    }
}