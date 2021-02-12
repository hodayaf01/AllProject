import { MedicineToUserByTime } from "./MdicineToUserByTime.model";
import { MedicineToUserByTimeResp } from "./MedicineToUserByTimeResp.model";


export class UpdateMedicineReq{
    CodeTimeToUser: MedicineToUserByTime;
    ListMedicines:Array<MedicineToUserByTimeResp>=[];
    CountSnooze: number;

    constructor(u?:MedicineToUserByTime, g?:Array<MedicineToUserByTimeResp>, c?:number){
        this.CodeTimeToUser=u;
        this.ListMedicines=g;
        this.CountSnooze=c;
    }
}
