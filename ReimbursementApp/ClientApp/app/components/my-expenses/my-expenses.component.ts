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

    @ViewChild('expenseIdInput') expenseIdInput;

    constructor(private router: Router, private expenseService: ExpenseService, private toastyService: ToastyService) { }

    ngOnInit() {

        this.expenseService.myExpenses()
            .subscribe(exp => {
                    this.expenses = exp;
                    if (this.expenses.length > 0) {
                        this.toastyService.success({
                            title: 'Success',
                            msg: 'Expenses Fetched!',
                            theme: 'bootstrap',
                            showClose: true,
                            timeout: 5000
                        });
                    } else {
                        this.toastyService.warning({
                            title: 'Info',
                            msg: 'No Expenses Submitted So-Far!',
                            theme: 'bootstrap',
                            showClose: true,
                            timeout: 5000
                        });
                    }
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

    clearExpense() {
        this.showHide = false;
        this.expenseIdInput.nativeElement.value = "";
    }



}