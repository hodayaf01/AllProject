
export class User{
    Id:number;
    childId:number;
    userName:string;
    email:string;
    password:string;
    userHMO:number;
    token: string;

    constructor(id?:number,un?:string,em?:string,pas?:string,uHMO?:number, token?:string, 
        ) {
        this.childId=id;
        this.userName=un;
        this.password=pas;
        this.userHMO=uHMO;    
        this.token = token;
    }

    addUser(){
        
    }
}

