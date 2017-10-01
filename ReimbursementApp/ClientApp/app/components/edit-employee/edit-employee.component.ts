import { Component, OnInit, Inject, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { Http } from '@angular/http';
import { EmployeeService } from '../../services/employee.service';
import { ToastyService } from "ng2-toasty";


@Component({
    selector: 'app-edit-employee',
    templateUrl: './edit-employee.component.html',
    styleUrls: ['./edit-employee.component.css']

})

export class EditEmployeeComponent implements OnInit {
    employees;
    id: any;
    showHide: boolean;
    desigSearch: boolean;
    idflag: boolean;
    desigFlag: boolean;
    nameFlag: boolean;
    managerFlag: boolean;

    @ViewChild('empIdInput') empIdInput;
    constructor(private router: Router, private employeeService: EmployeeService, private toastyService: ToastyService) { }

    ngOnInit() {
        this.showHide = false;
        this.desigSearch = false;
        this.idflag = true;
        this.desigFlag = true;
        this.nameFlag = true;
        this.managerFlag = true;
    }
    clearEmployee() {
        this.showHide = false;
        this.empIdInput.nativeElement.value = "";
    }
    searchEmployee() {
        //Search by Employee ID
        this.employeeService.getEmployee(this.empIdInput.nativeElement.value)
            .subscribe(e => {
                this.employees = e;
                console.log("Length:-", this.employees.length);
                console.log("Employee Fetched:-", this.employees);
                if (this.employees.length == 0) {
                    this.idflag = false;
                }
                    if (this.employees.length == 1) {
                    this.toastyService.success({
                        title: 'Success',
                        msg: 'Employee Fetched!',
                        theme: 'bootstrap',
                        showClose: true,
                        timeout: 5000
                    });
                }
                if (this.employees.length > 1) {
                    this.toastyService.success({
                        title: 'Success',
                        msg: 'Employees Fetched!',
                        theme: 'bootstrap',
                        showClose: true,
                        timeout: 5000
                    });
                }
                this.showHide = true;
                //Search by Employee Name
                if (this.employees.length == 0) {
                    this.employeeService.getEmployeeByName(this.empIdInput.nativeElement.value)
                        .subscribe(name => {
                            this.employees = name;
                            if (name.length == 0) {
                                //Search by Designation Name
                                this.employeeService.getEmployeeByDesig(this.empIdInput.nativeElement.value)
                                    .subscribe(desig => {
                                        this.employees = desig;
                                        //Search by Manager Name
                                        if (desig.length == 0) {
                                            this.employeeService
                                                .getEmployeeByManager(this.empIdInput.nativeElement.value)
                                                .subscribe(manager => {
                                                    this.employees = manager;
                                                    console.log("Emloyee Fetched via Manager:-", this.employees);
                                                    if (manager.length > 0) {
                                                        this.toastyService.success({
                                                            title: 'Success',
                                                            msg: 'Employee Fetched via Manager!',
                                                            theme: 'bootstrap',
                                                            showClose: true,
                                                            timeout: 5000
                                                        });
                                                    }
                                                    if (manager.length == 0) {
                                                        this.managerFlag = false;
                                                    }
                                              },
                                                err => {
                                                    if (err.status == 404) {
                                                        this.toastyService.error({
                                                            title: 'Error',
                                                            msg: 'An unexpected error while fetching the record!',
                                                            theme: 'bootstrap',
                                                            showClose: true,
                                                            timeout: 5000
                                                        });
                                                        this.router.navigate(['/']);
                                                    }
                                                });
                                        }
                                        if (desig.length > 0) {
                                            this.toastyService.success({
                                                title: 'Success',
                                                msg: 'Employee Fetched via designation!',
                                                theme: 'bootstrap',
                                                showClose: true,
                                                timeout: 5000
                                            });
                                            console.log("Employee Fetched via designation:-", this.employees);
                                        }
                                        if (desig.length == 0) {
                                            this.desigFlag = false;
                                        }

                                        },
                                    err => {
                                        if (err.status == 404) {
                                            this.toastyService.error({
                                                title: 'Error',
                                                msg: 'An unexpected error while fetching the record!',
                                                theme: 'bootstrap',
                                                showClose: true,
                                                timeout: 5000
                                            });
                                            this.router.navigate(['/']);
                                        }
                                    }
                                    );

                            }
                            if (name.length > 0) {
                                this.toastyService.success({
                                    title: 'Success',
                                    msg: 'Employee Fetched via name!',
                                    theme: 'bootstrap',
                                    showClose: true,
                                    timeout: 5000
                                });
                                console.log("Employee Fetched via name:-", this.employees);
                            }
                            if (name.length == 0) {
                                this.nameFlag = false;
                            }

                            }, err => {
                            if (err.status == 404) {
                                this.toastyService.error({
                                    title: 'Error',
                                    msg: 'An unexpected error while fetching the record!',
                                    theme: 'bootstrap',
                                    showClose: true,
                                    timeout: 5000
                                });
                                this.router.navigate(['/']);
                            }
                        });
                }
                //Checking Flag collection for not found scenario
                if (!this.idflag && !this.desigFlag && !this.managerFlag && !this.nameFlag) {
                    this.toastyService.warning({
                        title: 'Info',
                        msg: 'Employee Not Found!',
                        theme: 'bootstrap',
                        showClose: true,
                        timeout: 5000
                    });
                }
            },
            err => {
                if (err.status == 404) {
                    this.toastyService.error({
                        title: 'Error',
                        msg: 'An unexpected error while fetching the record!',
                        theme: 'bootstrap',
                        showClose: true,
                        timeout: 5000
                    });
                    this.router.navigate(['/']);
                }
            });
    }
}