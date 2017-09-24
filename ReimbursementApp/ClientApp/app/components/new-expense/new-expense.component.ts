import { Component, OnInit, Inject } from '@angular/core';

import { Http } from '@angular/http';
import { EmployeeService } from '../../services/employee.service';


@Component({
    selector: 'app-new-expense',
    templateUrl: './new-expense.component.html',
    styleUrls: ['./new-expense.component.css']

})

export class NewExpenseComponent implements OnInit {
    employees: any;

    constructor(private employeeService: EmployeeService) { }

    ngOnInit() {

    }
}