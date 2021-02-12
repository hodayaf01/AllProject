import { Component, OnInit } from '@angular/core';
import { MedicineToUserByTime } from 'src/app/Models/MdicineToUserByTime.model';
import { MedicineToUserByTimeResp } from 'src/app/Models/MedicineToUserByTimeResp.model';
import { MedicinesListService } from 'src/app/Services/MedicinesListService';
import { Router } from '@angular/router';

import { from } from 'rxjs';
import { UpdateMedicineReq } from 'src/app/Models/UpdateMedicineList.mode';

@Component({
    selector: 'app-MedicinesList',
    templateUrl: './MedicinesList.html',
    styleUrls: ['./MedicinesList.css']
})

export class MedicinesListComponent implements OnInit{
    subscribe: any;

    points: number;
    medicineListToUserByTime: MedicineToUserByTime = new MedicineToUserByTime();
    medicineToUserByTimeResp: Array<MedicineToUserByTimeResp> = new Array<MedicineToUserByTimeResp>();
    
    constructor(private medicineListService: MedicinesListService,private router: Router){
        
    }
    ngOnInit() {
        this.medicineToUserByTimeResp = [
            new MedicineToUserByTimeResp(1, "אקמול", 2, "גלולות", null),
            new MedicineToUserByTimeResp(1, "אדויל", 2, "זריקה", null),
            new MedicineToUserByTimeResp(1, "אופטלגין", 2, "טיפות", null),
            new MedicineToUserByTimeResp(1, "לאידוע", 2, "תרסיס", null),
            new MedicineToUserByTimeResp(1, "מוזר", 2, "שאיפה", null),
            new MedicineToUserByTimeResp(1, "ישתנה", 2, "סירופ", null),
        ];
        this.medicineListToUserByTime.UserID = +(localStorage.getItem('USERCODE')); //30010;
        this.medicineListToUserByTime.TimeOfDay = +(localStorage.getItem('TIMEOFALERT')); //1;

        // this.subscribe = this.medicineListService.get(this.medicineListToUserByTime).subscribe(
        //     result => {
        //         this.points=result.Points;
        //         console.log(result);
        //         for (let i = 0; i < result.length; i++) {
        //             this.medicineToUserByTimeResp[i] = new MedicineToUserByTimeResp();
        //             this.medicineToUserByTimeResp[i].medicineName = result[i].MedicineName;
        //             this.medicineToUserByTimeResp[i].Dosage = result[i].Dosage;
        //             this.medicineToUserByTimeResp[i].DosageName = result[i].DosageName;
        //         }
        //     }
        // );

    }

    setStatusToTrue(i:number){
        this.medicineToUserByTimeResp[i].Status = true;
        console.log(this.medicineToUserByTimeResp);
    }

    setStatusToFalse(i:number){
        this.medicineToUserByTimeResp[i].Status = false;
        console.log(this.medicineToUserByTimeResp);
    }

    updateTokenMedicines(){
        let updateMedicine = new UpdateMedicineReq();
        updateMedicine.CountSnooze= 7;//+localStorage.getItem('SNOOZECOUNETR');
        updateMedicine.CodeTimeToUser=new MedicineToUserByTime();
        updateMedicine.CodeTimeToUser.TimeOfDay=+(localStorage.getItem('TIMEOFALERT'));
        updateMedicine.CodeTimeToUser.UserID = +(localStorage.getItem('USERCODE'));
        updateMedicine.ListMedicines = this.medicineToUserByTimeResp;

        console.log(updateMedicine);
        //this.subscribe=this.medicineListService.update(this.medicineListToUserByTime).subscribe(
        this.subscribe=this.medicineListService.update(updateMedicine).subscribe(
            result=>{
                console.log('update')
                this.router.navigate(['/Home']);
            }
        );
    }
}