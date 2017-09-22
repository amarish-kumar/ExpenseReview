import { Component, OnInit, Inject, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { Http } from '@angular/http';
import { EmployeeService } from '../../services/employee.service';


@Component({
    selector: 'app-search-employee',
    templateUrl: './search-employee.component.html',
    styleUrls: ['./search-employee.component.css']

})

export class SearchEmployeeComponent implements OnInit {
    employees;
    id: any;
    showHide: boolean;
    @ViewChild('empIdInput') empIdInput;
    constructor(private router: Router,private employeeService: EmployeeService) { }

    ngOnInit() {
        this.showHide = false;
    }

    searchEmployee() {
        this.employeeService.getEmployee(this.empIdInput.nativeElement.value)
            .subscribe(e => {
                   // console.log(this.empIdInput.nativeElement);
                    this.employees = e;
                    console.log("Employee Fetched:-", this.employees);
                    this.showHide = true;
                },
                err => {
                    if (err.status == 404) {
                        this.router.navigate(['/']);
                    }
                });
    }
}