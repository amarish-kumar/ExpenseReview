import { Component, OnInit, Inject } from '@angular/core';
import { EmployeeService } from './employee.service';
import { Http } from '@angular/http';


@Component({
    selector: 'app-employee',
    templateUrl: './employee.component.html',
    styleUrls: ['./employee.component.css']
    
})

export class EmployeeComponent implements OnInit {
    employees: any;

    constructor(private employeeService: EmployeeService) {}
    /*   constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
           http.get(baseUrl + 'api/employee/').subscribe(result => {
               this.employees = result.json();
               console.log('Employees:-', this.employees);
           }, error => console.error(error));
       }*/

    ngOnInit() {
        this.employeeService.getEmployees().subscribe(employees => {
            this.employees = employees;
            console.log("Employees:- ", this.employees);

     });
    }
}