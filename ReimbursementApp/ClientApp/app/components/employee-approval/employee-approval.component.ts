import { Component, OnInit, Inject, ViewChild } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Http } from '@angular/http';
import { EmployeeService } from '../../services/employee.service';
import { ApproverService } from '../../services/approver.service';
import { ToastyService } from "ng2-toasty";
import { Employee } from './../../models/employee';
import { NgForm } from '@angular/forms';


@Component({
    selector: 'app-employee-approval',
    templateUrl: './employee-approval.component.html',
    styleUrls: ['./employee-approval.component.css']

})

export class EmployeeApprovalComponent implements OnInit {
    employee: Employee = new Employee();
    approvers;
    employees;
    showHide: boolean;
    desigSearch: boolean;
    idflag: boolean;
    desigFlag: boolean;
    nameFlag: boolean;
    managerFlag: boolean;


    @ViewChild('empIdInput') empIdInput;
    @ViewChild('employeeId') employeeId;
    constructor(
        private router: Router,
        private route: ActivatedRoute,
        private employeeService: EmployeeService,
        private approverService: ApproverService,
        private toastyService: ToastyService) {

    }

    ngOnInit() {
        this.showHide = false;
        this.desigSearch = false;
        this.idflag = true;
        this.desigFlag = true;
        this.nameFlag = true;
        this.managerFlag = true;

        this.approverService.getApprovers()
            .subscribe(app => {
                this.approvers = app;
            });
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

   
    //TODO:-Reject Employee
    rejectEmployee() {
        
    }

    approveEmployee(form: NgForm) {
      
        this.approverService.approveEmployee(form.value)
            .subscribe(e => {
                this.toastyService.success({
                    title: 'Success',
                    msg: 'Employee Approved!',
                    theme: 'bootstrap',
                    showClose: true,
                    timeout: 5000
                });
            },
            err => {
                this.toastyService.error({
                    title: 'Error',
                    msg: 'An unexpected error occured while approving employee!',
                    theme: 'bootstrap',
                    showClose: true,
                    timeout: 5000
                });
            });
    }

}