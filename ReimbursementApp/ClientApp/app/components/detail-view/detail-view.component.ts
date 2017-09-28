import { Component, OnInit, Inject, ViewChild } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Http } from '@angular/http';
import { ExpenseService } from '../../services/expense.service';
import { ToastyService } from "ng2-toasty";
import { Expense } from './../../models/expense';
import { NgForm } from '@angular/forms';

@Component({
    selector: 'app-detail-view',
    templateUrl: './detail-view.component.html',
    styleUrls: ['./detail-view.component.css']

})

export class DetailViewComponent implements OnInit {
    expenses;
    expense: Expense = new Expense();
    constructor(private router: Router,
        private route: ActivatedRoute,
        private expenseService: ExpenseService,
        private toastyService: ToastyService) {
        route.params.subscribe(p => {
            this.expense.expenseId = +p['id'];
        });
    }

    ngOnInit() {
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



}