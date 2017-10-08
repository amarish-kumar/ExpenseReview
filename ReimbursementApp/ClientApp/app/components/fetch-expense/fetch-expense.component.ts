import { Component, OnInit, Inject, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { Http } from '@angular/http';
import { ExpenseService } from '../../services/expense.service';
import { DocsService } from '../../services/document.service';
import { ToastyService } from "ng2-toasty";
import { Expense } from './../../models/expense';
import { NgForm } from '@angular/forms';
import { SafeResourceUrl, DomSanitizer } from '@angular/platform-browser';

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
    ExpenseObj;
    @ViewChild('expenseIdInput') expenseIdInput;
    docs: any[] = [];
    pdfs: any[] = [];
    expense: Expense = new Expense();
    constructor(
        private router: Router,
        private expenseService: ExpenseService,
        private toastyService: ToastyService,
        private docService: DocsService,
        private sanitizer: DomSanitizer) { }

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

    //Problem:- This does binding to all existing expenses
    /*fetchDocs(expenseIdValue) {
        this.docs = [];
        this.pdfs = [];
        this.docService.getDocs(expenseIdValue.value)
            .subscribe(doc => {
                for (var i = 0; i < doc[0].length; i++) {
                    if (doc[0][i].docName.endsWith(".pdf")) {
                        //PDFs Collection
                        doc[0][i].docName = this.sanitizer.bypassSecurityTrustResourceUrl('/uploads/' + doc[0][i].docName);
                        this.pdfs.push(doc[0][i]);
                        console.log("PDFs:- ", this.pdfs);
                    } else {
                        //Images Collection
                        this.docs.push(doc[0][i]);
                    }
                }
            }, err => {
                console.log("Error Occured while fetching docs!");
            });
    }*/
    searchExpense() {
        //Flushing the documents before every search
        this.docs = [];
        this.pdfs = [];
        //TODO:- Need to think on supplying associated expense id
        this.docs = [];
        this.pdfs = [];
        if (this.expenseIdInput.nativeElement.value!==''){
        this.docService.getDocs(this.expenseIdInput.nativeElement.value)
            .subscribe(doc => {
                for (var i = 0; i < doc[0].length; i++) {
                    if (doc[0][i].docName.endsWith(".pdf")) {
                        //PDFs Collection
                        doc[0][i].docName = this.sanitizer.bypassSecurityTrustResourceUrl('/uploads/' + doc[0][i].docName);
                        this.pdfs.push(doc[0][i]);
                        console.log("PDFs:- ", this.pdfs);
                    } else {
                        //Images Collection
                        this.docs.push(doc[0][i]);
                    }
                }
            }, err => {
                console.log("Error Occured while fetching docs!");
                });
        }
        //Search by Expense Id
        this.expenseService.getExpenseById(this.expenseIdInput.nativeElement.value)
            .subscribe(e => {
                this.expenses = e;
                this.ExpenseObj = e;
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
                                                .getExpenseByManager(this.expenseIdInput.nativeElement.value)
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

    //Approve expense based on expense id
    approveExpense(expIdInput, reasonInput, approvedDate) {
        var data = JSON.parse(JSON.stringify(this.ExpenseObj || null));
        this.ExpenseObj.reason = reasonInput.value;
        this.expenseService.approveExpense(expIdInput.value, reasonInput.value, approvedDate.value, this.ExpenseObj)
            .subscribe(e => {
                this.toastyService.success({
                    title: 'Info',
                    msg: 'Expense Approved!',
                    theme: 'bootstrap',
                    showClose: true,
                    timeout: 5000
                });
            }, err => {
                this.toastyService.error({
                    title: 'Info',
                    msg: 'Error occured while approving!',
                    theme: 'bootstrap',
                    showClose: true,
                    timeout: 5000
                });

            });
    }

    rejectExpense(expIdInput, reasonInput, approvedDate) {
        this.expenseService.rejectExpense(expIdInput.value, reasonInput.value, approvedDate.value, this.ExpenseObj)
            .subscribe(e => {
                this.toastyService.warning({
                    title: 'Info',
                    msg: 'Expense Rejected!',
                    theme: 'bootstrap',
                    showClose: true,
                    timeout: 5000
                });
            }, err => {
                this.toastyService.error({
                    title: 'Info',
                    msg: 'Error occured while rejecting!',
                    theme: 'bootstrap',
                    showClose: true,
                    timeout: 5000
                });

            });
    }

}