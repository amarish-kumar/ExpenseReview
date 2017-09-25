import { Component, OnInit, Inject } from '@angular/core';
import { Expense } from './../../models/expense';
import { Http } from '@angular/http';
import { ExpenseService } from '../../services/expense.service';
import { ApproverService } from '../../services/approver.service';
import { NgForm } from '@angular/forms';


@Component({
    selector: 'app-new-expense',
    templateUrl: './new-expense.component.html',
    styleUrls: ['./new-expense.component.css']

})

export class NewExpenseComponent implements OnInit {
    expense: Expense = new Expense();
    approvers;
    constructor(private expenseService: ExpenseService, private approverService:ApproverService) { }

    ngOnInit() {
        this.approverService.getApprovers()
            .subscribe(app => {
                this.approvers = app;
            });
    }

    onSubmit(form: NgForm) {
        var formData = this.expense;
        formData.expenseId = 0;
        formData.employeeId = this.expense.employeeId;
       // formData.
    }
}