import { Component, OnInit } from '@angular/core';
import { MedicineToUserByTime } from 'src/app/Models/MdicineToUserByTime.model';
import { MedicineToUserByTimeResp } from 'src/app/Models/MedicineToUserByTimeResp.model';
import { MedicinesListService } from 'src/app/Services/MedicinesListService';
import { Router } from '@angular/router';

import { from } from 'rxjs';

@Component({
    selector: 'app-MedicinesList',
    templateUrl: './MedicinesList.html',
    styleUrls: ['./MedicinesList.css']
})

export class MedicinesListComponent implements OnInit{
    subscribe: any;

    medicineListToUserByTime: MedicineToUserByTime = new MedicineToUserByTime();
    medicineToUserByTimeResp: Array<MedicineToUserByTimeResp> = new Array<MedicineToUserByTimeResp>();
    constructor(private medicineListService: MedicinesListService,private router: Router){
        
    }
    ngOnInit() {
        this.medicineListToUserByTime.UserID = 30010;
        this.medicineListToUserByTime.TimeOfDay = 1;

        this.subscribe = this.medicineListService.get(this.medicineListToUserByTime).subscribe(
            result => {
                console.log(result);
                for (let i = 0; i < result.length; i++) {
                    this.medicineToUserByTimeResp[i] = new MedicineToUserByTimeResp();
                    this.medicineToUserByTimeResp[i].medicineName = result[i].MedicineName;
                    this.medicineToUserByTimeResp[i].dosage = result[i].Dosage;
                    this.medicineToUserByTimeResp[i].dosageName = result[i].DosageName;
                }
            }
        );

    }

    updateTokenMedicines(){
        console.log(this.medicineListToUserByTime);
        this.subscribe=this.medicineListService.update(this.medicineListToUserByTime).subscribe(
            result=>{
                console.log('update')
                this.router.navigate(['/Home']);
            }
        );
    }
}