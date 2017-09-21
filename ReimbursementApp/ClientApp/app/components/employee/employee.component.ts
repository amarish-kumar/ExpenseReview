import { Component, OnInit } from '@angular/core';
import { EmployeeService } from './employee.service';


@Component({
    selector: 'app-employee',
    templateUrl: './employee.component.html',
    styleUrls:['./employee.component.css'],
    providers:[EmployeeService]
    
})

export class EmployeeComponent implements OnInit {
    employees:any;
    constructor(private employeeService:EmployeeService) { }

    ngOnInit() {
        this.employeeService.getEmployees().subscribe(employees => {
            this.employees = employees;
            console.log("Employees:- ", this.employees);

     });
    }
}