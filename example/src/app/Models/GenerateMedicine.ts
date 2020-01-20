export class GenerateMedicine{

    Id :Number
    MedicineName:string
    Dosage:Number
    DosageName:string
    constructor(i:number,m:string,d:Number,dN:string)
    {
        this.Id=i;
        this.MedicineName=m;
        this.Dosage=d;
        this.DosageName=dN;
    }
        
}