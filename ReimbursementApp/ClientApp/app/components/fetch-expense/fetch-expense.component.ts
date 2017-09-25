import { Component, OnInit, Inject, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { Http } from '@angular/http';
import { ExpenseService } from '../../services/expense.service';
import { ToastyService } from "ng2-toasty";

@Component({
    selector: 'app-fetch-expense',
    templateUrl: './fetch-expense.component.html',
    styleUrls: ['./fetch-expense.component.css']

})

export class FetchExpenseComponent implements OnInit {
    showHide: boolean;
    expenses;
    idFlag: boolean;
    desigFlag: boolean;
    nameFlag: boolean;
    managerFlag: boolean;
    @ViewChild('expenseIdInput') expenseIdInput;
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
    searchExpense() {
        //Search by Expense Id
        this.expenseService.getExpenseById(this.expenseIdInput.nativeElement.value)
            .subscribe(e => {
                this.expenses = e;
                if (this.expenses.length == 0) {
                    this.idFlag = false;
                }
                if (this.expenses.length == 1) {
                    this.toastyService.success({
                        title: 'Success',
                        msg: 'Expense Fetched!',
                        theme: 'bootstrap',
                        showClose: true,
                        timeout: 5000
                    });
                }
                if (this.expenses.length > 1) {
                    this.toastyService.success({
                        title: 'Success',
                        msg: 'Expenses Fetched!',
                        theme: 'bootstrap',
                        showClose: true,
                        timeout: 5000
                    });
                }
                this.showHide = true;
                //Search by EmployeeName
                if (this.expenses.length == 0) {
                    this.expenseService.getExpenseByName(this.expenseIdInput.nativeElement.value)
                        .subscribe(name => {
                            this.expenses = name;
                            if (name.length == 0) {
                                //Search by Designation Name
                                this.expenseService.getExpenseByDesig(this.expenseIdInput.nativeElement.value)
                                    .subscribe(desig => {
                                        this.expenses = desig;
                                        //Search by Manager Name
                                        if (desig.length == 0) {
                                            this.expenseService
                                                .getExpenseByDesig(this.expenseIdInput.nativeElement.value)
                                                .subscribe(manager => {
                                                    this.expenses = manager;
                                                    if (manager.length > 0) {
                                                        this.toastyService.success({
                                                            title: 'Success',
                                                            msg: 'Expense Fetched via Manager!',
                                                            theme: 'bootstrap',
                                                            showClose: true,
                                                            timeout: 5000
                                                        });
                                                    }
                                                    if (manager.length == 0) {
                                                        this.managerFlag = false;
                                                    }
                                                },
                                                err => {
                                                    if (err.status == 404) {
                                                        this.toastyService.error({
                                                            title: 'Error',
                                                            msg:
                                                            'An unexpected error while fetching the record!',
                                                            theme: 'bootstrap',
                                                            showClose: true,
                                                            timeout: 5000
                                                        });
                                                        this.router.navigate(['/']);
                                                    }
                                                });
                                        }
                                        if (desig.length > 0) {
                                            this.toastyService.success({
                                                title: 'Success',
                                                msg: 'Expense Fetched via designation!',
                                                theme: 'bootstrap',
                                                showClose: true,
                                                timeout: 5000
                                            });
                                            console.log("Expense Fetched via designation:-",
                                                this.expenses);
                                        }
                                        if (desig.length == 0) {
                                            this.desigFlag = false;
                                        }

                                    },
                                    err => {
                                        if (err.status == 404) {
                                            this.toastyService.error({
                                                title: 'Error',
                                                msg: 'An unexpected error while fetching the record!',
                                                theme: 'bootstrap',
                                                showClose: true,
                                                timeout: 5000
                                            });
                                            this.router.navigate(['/']);
                                        }
                                    });
                            }
                            if (name.length > 0) {
                                this.toastyService.success({
                                    title: 'Success',
                                    msg: 'Expense Fetched via name!',
                                    theme: 'bootstrap',
                                    showClose: true,
                                    timeout: 5000
                                });
                                console.log("Expense Fetched via name:-", this.expenses);
                            }
                            if (name.length == 0) {
                                this.nameFlag = false;
                            }
                        },
                        err => {
                            if (err.status == 404) {
                                this.toastyService.error({
                                    title: 'Error',
                                    msg: 'An unexpected error while fetching the record!',
                                    theme: 'bootstrap',
                                    showClose: true,
                                    timeout: 5000
                                });
                                this.router.navigate(['/']);
                            }
                        });
                }
                //Checking Flag collection for not found scenario
                if (!this.idFlag && !this.desigFlag && !this.managerFlag && !this.nameFlag) {
                    this.toastyService.warning({
                        title: 'Info',
                        msg: 'Expense Not Found!',
                        theme: 'bootstrap',
                        showClose: true,
                        timeout: 5000
                    });
                }
            },
            err => {
                if (err.status == 404) {
                    this.toastyService.error({
                        title: 'Error',
                        msg: 'An unexpected error while fetching the record!',
                        theme: 'bootstrap',
                        showClose: true,
                        timeout: 5000
                    });
                    this.router.navigate(['/']);
                }
            });
    }
}