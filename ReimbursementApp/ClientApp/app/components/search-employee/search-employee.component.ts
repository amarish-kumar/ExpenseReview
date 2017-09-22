import { Component, OnInit, Inject } from '@angular/core';

import { Http } from '@angular/http';
import { EmployeeService } from '../../services/employee.service';


@Component({
    selector: 'app-search-employee',
    templateUrl: './search-employee.component.html',
    styleUrls: ['./search-employee.component.css']

})

export class SearchEmployeeComponent implements OnInit {
    employees: any;

    constructor(private employeeService: EmployeeService) { }

    ngOnInit() {

    }
}