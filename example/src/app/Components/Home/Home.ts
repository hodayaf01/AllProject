import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
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

    points: number;
    medicineListToUserByTime: MedicineToUserByTime = new MedicineToUserByTime();
    medicineToUserByTimeResp1: Array<MedicineToUserByTimeResp> = new Array<MedicineToUserByTimeResp>();
    medicineToUserByTimeResp2: Array<MedicineToUserByTimeResp> = new Array<MedicineToUserByTimeResp>();
    medicineToUserByTimeResp3: Array<MedicineToUserByTimeResp> = new Array<MedicineToUserByTimeResp>();
    medicineToUserByTimeResp4: Array<MedicineToUserByTimeResp> = new Array<MedicineToUserByTimeResp>();


    constructor(private medicineListService: MedicinesListService, private router: Router, ){
    }

    //call 4 times to medicine to chiled to user.
    ngOnInit(): void {
        this.medicineToUserByTimeResp1 = [
            new MedicineToUserByTimeResp(1, "אקמול", 2, "גלולות", null, false),
            new MedicineToUserByTimeResp(1, "אדויל", 2, "זריקה",  null, false),
        ];

        this.medicineToUserByTimeResp2 = [
            new MedicineToUserByTimeResp(1, "אקמול", 2, "גלולות", null, false),
            new MedicineToUserByTimeResp(1, "אדויל", 2, "זריקה",  null, false),
            new MedicineToUserByTimeResp(1, "אופטלגין", 2, "טיפות", null, false),
            new MedicineToUserByTimeResp(1, "לאידוע", 2, "תרסיס", null, false),
        ];

        this.medicineToUserByTimeResp3 = [
            new MedicineToUserByTimeResp(1, "אקמול", 2, "גלולות", null, false),
            new MedicineToUserByTimeResp(1, "אדויל", 2, "זריקה",  null, false),
            new MedicineToUserByTimeResp(1, "אופטלגין", 2, "טיפות", null, false),
        ];

        this.medicineToUserByTimeResp4 = [
            new MedicineToUserByTimeResp(1, "אקמול", 2, "גלולות", null, false),
            new MedicineToUserByTimeResp(1, "אדויל", 2, "זריקה",  null, false),
        ];

        this.points=125;

        //this.medicineListToUserByTime.user= parseInt(localStorage.getItem('USERCODE'));
        this.medicineListToUserByTime.UserID = 30010;
        this.medicineListToUserByTime.TimeOfDay = 1;

        // this.subscribe = this.medicineListService.get(this.medicineListToUserByTime).subscribe(
        //     result => {
        //         console.log(result);
        //         this.points= result.Points;
        //         for (let i = 0; i < result.length; i++) {
        //             this.medicineToUserByTimeResp1[i] = new MedicineToUserByTimeResp();
        //             this.medicineToUserByTimeResp1[i].medicineName = result[i].MedicineName;
        //             this.medicineToUserByTimeResp1[i].Dosage = result[i].Dosage;
        //             this.medicineToUserByTimeResp1[i].DosageName = result[i].DosageName;
        //             this.medicineToUserByTimeResp1[i].Status = result[i].Status;
        //             this.medicineToUserByTimeResp1[i].Time = result[i].Time;
        //             this.medicineToUserByTimeResp1[i].Points = result[i].Points;
        //         }

        //         this.medicineListToUserByTime.TimeOfDay = 2;
        //         this.subscribe = this.medicineListService.get(this.medicineListToUserByTime).subscribe(
        //             result => {
        //                 console.log(result);
        //                 for (let i = 0; i < result.length; i++) {
        //                     this.medicineToUserByTimeResp2[i] = new MedicineToUserByTimeResp();
        //                     this.medicineToUserByTimeResp2[i].medicineName = result[i].MedicineName;
        //                     this.medicineToUserByTimeResp2[i].Dosage = result[i].Dosage;
        //                     this.medicineToUserByTimeResp2[i].DosageName = result[i].DosageName;
        //                     this.medicineToUserByTimeResp2[i].Status = result[i].Status;
        //                     this.medicineToUserByTimeResp2[i].Time = result[i].Time;
        //                 }

        //                 this.medicineListToUserByTime.TimeOfDay = 3;
        //                 this.subscribe = this.medicineListService.get(this.medicineListToUserByTime).subscribe(
        //                     result => {
        //                         console.log(result);
        //                         for (let i = 0; i < result.length; i++) {
        //                             this.medicineToUserByTimeResp3[i]=new MedicineToUserByTimeResp();
        //                             this.medicineToUserByTimeResp3[i].medicineName = result[i].MedicineName;
        //                             this.medicineToUserByTimeResp3[i].Dosage = result[i].Dosage;
        //                             this.medicineToUserByTimeResp3[i].DosageName = result[i].DosageName;
        //                             this.medicineToUserByTimeResp3[i].Status = result[i].Status;
        //                             this.medicineToUserByTimeResp3[i].Time = result[i].Time;
        //                         }


        //                         this.medicineListToUserByTime.TimeOfDay = 4;
        //                         this.subscribe = this.medicineListService.get(this.medicineListToUserByTime).subscribe(
        //                             result => {
        //                                 console.log(result);
        //                                 for (let i = 0; i < result.length; i++) {
        //                                     this.medicineToUserByTimeResp4[i]=new MedicineToUserByTimeResp();
        //                                     this.medicineToUserByTimeResp4[i].medicineName = result[i].MedicineName;
        //                                     this.medicineToUserByTimeResp4[i].Dosage = result[i].Dosage;
        //                                     this.medicineToUserByTimeResp4[i].DosageName = result[i].DosageName;
        //                                     this.medicineToUserByTimeResp4[i].Status = result[i].Status;
        //                                     this.medicineToUserByTimeResp4[i].Time = result[i].Time;
        //                                 }
        //                             }
        //                         );

        //                     }
        //                 );
        //             }
        //         );

        //     }
        // );

    }

    navigateToSettings(){
        this.router.navigate(['/TimeOfAlert']);
    }
}