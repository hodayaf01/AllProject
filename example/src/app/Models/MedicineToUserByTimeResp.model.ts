export class MedicineToUserByTimeResp{
    Id: number;
    medicineName: string;
    Dosage: number;
    DosageName: string;
    Points: number;
    Status:boolean;
    Time: string;

    constructor(i?:number, mn?:string, d?:number, dn?:string, p?:number, s?:boolean){
        this.Points=i;
        this.medicineName=mn;
        this.DosageName=dn;
        this.Dosage=d;
        this.Points=p;
        this.Status=s;
    }

}