import { Component, OnInit } from '@angular/core';
import { MedicineToUserByTime } from 'src/app/Models/MdicineToUserByTime.model';
import { MedicineToUserByTimeResp } from 'src/app/Models/MedicineToUserByTimeResp.model';
import { MedicinesListService } from 'src/app/Services/MedicinesListService';

@Component({
    selector: 'app-Home',
    templateUrl: './Home.html',
    styleUrls: ['./Home.css']
})
export class HomeComponent implements OnInit{
    subscribe: any;
    medicineListToUserByTime: MedicineToUserByTime;
    medicineToUserByTimeResp1: Array<MedicineToUserByTimeResp> = [{medicineName: "אקמול", dosage:2, dosageName: "ml"}, {medicineName: "אקמול", dosage:2, dosageName: "ml"}, {medicineName: "אקמול", dosage:2, dosageName: "ml"}];
    medicineToUserByTimeResp2: Array<MedicineToUserByTimeResp> = [{medicineName: "אקמול", dosage:2, dosageName: "ml"}];
    medicineToUserByTimeResp3: Array<MedicineToUserByTimeResp> = [{medicineName: "אקמול", dosage:2, dosageName: "ml"}, {medicineName: "אקמול", dosage:2, dosageName: "ml"}];
    medicineToUserByTimeResp4: Array<MedicineToUserByTimeResp> = [];

    date:Date = new Date();
    

    constructor(private medicineListService: MedicinesListService){
        this.date.setHours(12);
        this.date.toUTCString();
    }

    //call 4 times to medicine to chiled to user.
    ngOnInit(): void {
    //     this.medicineListToUserByTime.user= parseInt(localStorage.getItem('USERCODE'));
    //     this.medicineListToUserByTime.timeCode = 1;

    //     this.subscribe = this.medicineListService.get(this.medicineListToUserByTime).subscribe(
    //         result => {
    //             console.log(result);
    //             for (let i = 0; i < result.length; i++) {
    //                 this.medicineToUserByTimeResp1[i].medicineName = result[i].MedicineName;
    //                 this.medicineToUserByTimeResp1[i].dosage = result[i].Dosage;
    //                 this.medicineToUserByTimeResp1[i].dosageName = result[i].DosageName;
    //             }
    //         }
    //     );

    //     this.medicineListToUserByTime.timeCode = 2;
    //     this.subscribe = this.medicineListService.get(this.medicineListToUserByTime).subscribe(
    //         result => {
    //             console.log(result);
    //             for (let i = 0; i < result.length; i++) {
    //                 this.medicineToUserByTimeResp2[i].medicineName = result[i].MedicineName;
    //                 this.medicineToUserByTimeResp2[i].dosage = result[i].Dosage;
    //                 this.medicineToUserByTimeResp2[i].dosageName = result[i].DosageName;
    //             }
    //         }
    //     );

    //     this.medicineListToUserByTime.timeCode = 3;
    //     this.subscribe = this.medicineListService.get(this.medicineListToUserByTime).subscribe(
    //         result => {
    //             console.log(result);
    //             for (let i = 0; i < result.length; i++) {
    //                 this.medicineToUserByTimeResp3[i].medicineName = result[i].MedicineName;
    //                 this.medicineToUserByTimeResp3[i].dosage = result[i].Dosage;
    //                 this.medicineToUserByTimeResp3[i].dosageName = result[i].DosageName;
    //             }
    //         }
    //     );

    //     this.medicineListToUserByTime.timeCode = 4;
    //     this.subscribe = this.medicineListService.get(this.medicineListToUserByTime).subscribe(
    //         result => {
    //             console.log(result);
    //             for (let i = 0; i < result.length; i++) {
    //                 this.medicineToUserByTimeResp4[i].medicineName = result[i].MedicineName;
    //                 this.medicineToUserByTimeResp4[i].dosage = result[i].Dosage;
    //                 this.medicineToUserByTimeResp4[i].dosageName = result[i].DosageName;
    //             }
    //         }
    //     );

    

    }
}