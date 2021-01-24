
export class User{
    childId:number;
    userId:string;
    userName:string;
    phone:string
    email:string;
    password:string;
    userHMO:number;
    token: string;


    constructor(id?:number,uId?:string,un?:string,ph?:string,em?:string,pas?:string,uHMO?:number, token?:string, 
        ) {
        this.childId=id;
        this.userId=uId;
        this.userName=un;
        this.phone=ph;
        this.password=pas;
        this.userHMO=uHMO;    
        this.token = token;
    }

    addUser(){
        
    }
}

