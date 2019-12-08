export class Guardian{
    Id:number;
    guardianName:string;
    PhoneNumber:string

    constructor(Id?:number,guardianName?:string,PhoneNumber?:string){
        this.Id=Id;//check if I need to send the ID
        this.guardianName=guardianName;
        this.PhoneNumber=PhoneNumber;
    }
}