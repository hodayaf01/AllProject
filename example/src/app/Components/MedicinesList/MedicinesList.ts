import { Component, OnInit } from '@angular/core';
import { MedicinesListService } from '../../Services/MedicinesListService'
import { from } from 'rxjs';

@Component({
    selector: 'app-MedicinesList',
    templateUrl: './MedicinesList.html',
    styleUrls: ['./MedicinesList.css']
})

export class MedicinesListComponent implements OnInit{

    subscribe: any;

    constructor(private medicinesListService: MedicinesListService){
        
    }
    ngOnInit() {
    }
}