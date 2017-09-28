import { Component, OnInit, Inject } from '@angular/core';
import { Expense } from './../../models/expense';
import { Http } from '@angular/http';
import { ExpenseService } from '../../services/expense.service';
import { ApproverService } from '../../services/approver.service';
import { ExpCategoryService } from '../../services/expCategory.service';
import { EmployeeService } from '../../services/employee.service';
import { NgForm } from '@angular/forms';
import { ToastyService } from "ng2-toasty";

@Component({
    selector: 'app-new-expense',
    templateUrl: './new-expense.component.html',
    styleUrls: ['./new-expense.component.css']

})

export class NewExpenseComponent implements OnInit {
    expense: Expense = new Expense();
    approvers;
    expCategories;
    employees;
    constructor(private expenseService: ExpenseService,
        private approverService: ApproverService,
        private expCategoryService: ExpCategoryService,
        private employeeService: EmployeeService,
        private toastyService: ToastyService) { }

    ngOnInit() {
        this.expCategoryService.getExpCategories()
            .subscribe(exp => {
                this.expCategories = exp;
            });
        this.approverService.getApprovers()
            .subscribe(app => {
                this.approvers = app;
            });
        //Think on the logic of gett

    }

    onSubmit(form: NgForm) {
        var formData = this.expense;
        formData.expenseId = 0;
        // formData.employeeId = this.expense.employeeId;
        // formData.employeeName = this.expense.employeeName;
        formData.approverId = this.expense.approverId;
        formData.approverName = this.expense.approverName;
        formData.expenseDate = this.expense.expenseDate;
        formData.submitDate = this.expense.submitDate;
        formData.approvedDate = this.expense.approvedDate;
        formData.amount = this.expense.amount;
        formData.totalAmount = this.expense.totalAmount;
        formData.expenseDetails = this.expense.expenseDetails;
        formData.ticketStatus = this.expense.ticketStatus;
        formData.expCategory = this.expense.expCategory;

        this.expenseService.submitExpense(formData)
            .subscribe(exp => {
                    this.toastyService.success({
                        title: 'Success',
                        msg: 'New Expense Created!',
                        theme: 'bootstrap',
                        showClose: true,
                        timeout: 5000
                    });
                },
                err => {
                    this.toastyService.error({
                        title: 'Error',
                        msg: 'An unexpected error occured while creating new Expense!',
                        theme: 'bootstrap',
                        showClose: true,
                        timeout: 5000
                    });
                });
    }
}