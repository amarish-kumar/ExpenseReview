import { ExpCategory } from "./expCategory";

export class Expense {
    public expenseId: number;
    public employeeId:number=null;
    public employeeName: string = null;
    public approverId: number = null;
    public approverName: string = null;
    public expenseDate: string = null;
    public submitDate: string = null;
    public approvedDate: string = null;
    public amount: number = null;
    public totalAmount: number = null;
    public expenseDetails: string = null;
    public ticketStatus: boolean = null;
    public reason: string = null;
    public rejectedFlag:string=null;
    public expCategory: ExpCategory = {category:'Some',categoryId:18};
    public docName:string=null;

}

