import { Component, OnInit, Inject } from '@angular/core';
import { Expense } from './../../models/expense';
import { Http } from '@angular/http';
import { ExpenseService } from '../../services/expense.service';
import { NgForm } from '@angular/forms';


@Component({
    selector: 'app-new-expense',
    templateUrl: './new-expense.component.html',
    styleUrls: ['./new-expense.component.css']

})

export class NewExpenseComponent implements OnInit {
    expense: Expense = new Expense();

    constructor(private expenseService: ExpenseService) { }

    ngOnInit() {

    }

    onSubmit(form: NgForm) {
        
    }
}