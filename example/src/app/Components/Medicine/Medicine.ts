import { OnInit, Component } from '@angular/core';

@Component({
    selector: 'app-Medicine',
    templateUrl: './Medicine.html',
    styleUrls: ['./Medicine.css']
})

export class MedicineComponent implements OnInit{
    ngOnInit() {
        console.log("alert page");
    }
}