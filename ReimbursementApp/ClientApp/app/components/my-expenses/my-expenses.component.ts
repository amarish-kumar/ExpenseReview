import { Component, OnInit, Inject, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { Http } from '@angular/http';
import { ExpenseService } from '../../services/expense.service';
import { ToastyService } from "ng2-toasty";
import { Expense } from './../../models/expense';
import { NgForm } from '@angular/forms';

@Component({
    selector: 'app-my-expenses',
    templateUrl: './my-expenses.component.html',
    styleUrls: ['./my-expenses.component.css']

})

export class MyExpensesComponent implements OnInit {
    showHide: boolean;
    expenses;
    idFlag: boolean;
    desigFlag: boolean;
    nameFlag: boolean;
    managerFlag: boolean;
    ExpenseObj;
    @ViewChild('expenseIdInput') expenseIdInput;
    expense: Expense = new Expense();
    constructor(private router: Router, private expenseService: ExpenseService, private toastyService: ToastyService) { }

    ngOnInit() {
        this.showHide = false;
        this.idFlag = true;
        this.desigFlag = true;
        this.nameFlag = true;
        this.managerFlag = true;
        
    }

    clearExpense() {
        this.showHide = false;
        this.expenseIdInput.nativeElement.value = "";
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