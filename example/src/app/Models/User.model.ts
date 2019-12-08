
export class User{
    Id:number;
    userId:string;
    userName:string;
    phone:string
    email:string;
    password:string;
    userHMO:number

    constructor(id?:number,uId?:string,un?:string,ph?:string,em?:string,pas?:string,uHMO?:number) {
        this.Id=id;
        this.userId=uId;
        this.userName=un;
        this.phone=ph;
        this.password=pas;
        this.userHMO=uHMO;    
    }

    addUser(){
        
    }
}

