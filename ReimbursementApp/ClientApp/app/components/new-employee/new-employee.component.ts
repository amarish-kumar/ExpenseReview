import { Component, OnInit, Inject } from '@angular/core';

import { Http } from '@angular/http';
import { EmployeeService } from '../../services/employee.service';


@Component({
    selector: 'app-new-employee',
    templateUrl: './new-employee.component.html',
    styleUrls: ['./new-employee.component.css']

})

export class NewEmployeeComponent implements OnInit {
    employees: any;

    constructor(private employeeService: EmployeeService) { }
    
    ngOnInit() {
       
    }
}