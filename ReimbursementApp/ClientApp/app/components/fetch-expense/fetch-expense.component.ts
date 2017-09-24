import { Component, OnInit, Inject } from '@angular/core';

import { Http } from '@angular/http';
import { ExpenseService } from '../../services/expense.service';


@Component({
    selector: 'app-fetch-expense',
    templateUrl: './fetch-expense.component.html',
    styleUrls: ['./fetch-expense.component.css']

})

export class FetchExpenseComponent implements OnInit {
    showHide: boolean;
    expenses;

    constructor(private expenseService: ExpenseService) { }

    ngOnInit() {
        this.showHide = false;
    }
}