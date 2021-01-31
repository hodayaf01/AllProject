
export class Guardian{
    Id:number;
    guardianName:string;
    PhoneNumber:string

    constructor(Id?:number,guardianName?:string,PhoneNumber?:string){
        this.Id=Id;
        this.guardianName=guardianName;
        this.PhoneNumber=PhoneNumber;
    }
}