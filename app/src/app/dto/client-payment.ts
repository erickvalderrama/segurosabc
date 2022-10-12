export class ClientPayment{
    public amount:number;
    public date:string;
    public fullName:string;
    public idPayment:number;
    public identification:string;
    public pin:string;
    constructor() {
        this.amount=0;
        this.date='';
        this.fullName='';
        this.idPayment=0;
        this.identification='';
        this.pin = '';
    }
}