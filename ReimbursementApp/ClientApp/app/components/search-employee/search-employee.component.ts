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
    employee: any;
    id: any;
    @ViewChild('empIdInput') empIdInput;
    constructor(private router: Router,private employeeService: EmployeeService) { }

    ngOnInit() {

    }

    searchEmployee() {
        this.employeeService.getEmployee(this.empIdInput.nativeElement.value)
            .subscribe(e => {
                   // console.log(this.empIdInput.nativeElement);
                    this.employee = e;
                    console.log("Employee Fetched:-", this.employee);
                },
                err => {
                    if (err.status == 404) {
                        this.router.navigate(['/']);
                    }
                });
    }
}