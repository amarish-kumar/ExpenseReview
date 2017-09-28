import { Component, OnInit, Inject, ViewChild } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Http } from '@angular/http';
import { ExpenseService } from '../../services/expense.service';
import { ExpCategoryService } from '../../services/expCategory.service';
import { ToastyService } from "ng2-toasty";
import { Expense } from './../../models/expense';
import { NgForm } from '@angular/forms';

@Component({
    selector: 'app-edit-expense',
    templateUrl: './edit-expense.component.html',
    styleUrls: ['./edit-expense.component.css']

})

export class EditExpenseComponent implements OnInit {
    expenses;
    ExpenseObj;
    expCategories;
    expense: Expense = new Expense();
    constructor(private router: Router,
        private route: ActivatedRoute,
        private expenseService: ExpenseService,
        private toastyService: ToastyService,
        private expCategoryService: ExpCategoryService) {
        route.params.subscribe(p => {
            this.expense.expenseId = +p['id'];
        });
    }

    ngOnInit() {
        this.expCategoryService.getExpCategories()
            .subscribe(exp => {
                this.expCategories = exp;
            });
        this.expenseService.getExpenseById(this.expense.expenseId)
            .subscribe(e => {
                    //Since, I am sending the component back as querable data from server.
                    //But, in case of ID, it will be only one.
                    this.expenses = e[0];
                    this.toastyService.success({
                        title: 'Success',
                        msg: 'Expense retieved successfully!',
                        theme: 'bootstrap',
                        showClose: true,
                        timeout: 5000
                    });
                },
                err => {
                    this.toastyService.error({
                        title: 'Error',
                        msg: 'Error Occured while Fetching Expenses!',
                        theme: 'bootstrap',
                        showClose: true,
                        timeout: 5000
                    });
                });
       
    }

    onSubmit(form: NgForm) {
        var formData = this.expense;
        formData.expenseId = this.expenses.expenseId;
        formData.employeeId = this.expenses.employeeId;
        formData.employeeName = this.expenses.employeeName;
        formData.expenseDate = this.expenses.expenseDate;
        formData.submitDate = this.expenses.submitDate;
        formData.approvedDate = this.expenses.approvedDate;
        formData.approverId = this.expenses.approverId;
        formData.approverName = this.expenses.approverName;
        formData.expCategory = this.expenses.expCategory;
        formData.amount = this.expenses.amount;
        formData.totalAmount = this.expenses.totalAmount;
        formData.expenseDetails = this.expenses.expenseDetails;
        formData.ticketStatus = this.expenses.ticketStatus;
        formData.reason = this.expenses.reason;

        this.expenseService.editExpense(formData)
            .subscribe(exp => {
                    this.toastyService.success({
                        title: 'Success',
                        msg: 'Expense Edited Successfully',
                        theme: 'bootstrap',
                        showClose: true,
                        timeout: 5000
                    });
                },
                err => {
                    this.toastyService.error({
                        title: 'Error',
                        msg: 'An unexpected error occured while editing Expense!',
                        theme: 'bootstrap',
                        showClose: true,
                        timeout: 5000
                    });
                });
    }
  
 

}