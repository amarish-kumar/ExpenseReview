import { Component, OnInit, Inject, ViewChild } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Http } from '@angular/http';
import { EmployeeService } from '../../services/employee.service';
import { ApproverService } from '../../services/approver.service';
import { AssignRoleService } from '../../services/assignRole.service';
import { ToastyService } from "ng2-toasty";
import { Employee } from './../../models/employee';
import { Role } from './../../models/role';
import { NgForm } from '@angular/forms';


@Component({
    selector: 'app-assign-role',
    templateUrl: './assign-role.component.html',
    styleUrls: ['./assign-role.component.css']

})

export class AssignRoleComponent implements OnInit {
    employee: Employee = new Employee();
    role:Role= new Role();
    roles;
    approvers;
    employees;
    showHide: boolean;
    desigSearch: boolean;
    idflag: boolean;
    desigFlag: boolean;
    nameFlag: boolean;
    managerFlag: boolean;

    @ViewChild('empIdInput') empIdInput;
    @ViewChild('reportingManager') reportingManager;
    @ViewChild('roleName') roleName;
    constructor(
        private router: Router,
        private route: ActivatedRoute,
        private employeeService: EmployeeService,
        private approverService:ApproverService,
        private roleService: AssignRoleService,
        private toastyService: ToastyService) {

    }

    clearEmployee() {
        this.showHide = false;
        this.empIdInput.nativeElement.value = "";
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
                console.log("Approvers List", this.approvers);
            });

        this.roleService.getRoles()
            .subscribe(app => {
                this.roles = app;
                console.log('Roles Fetched', this.roles);
            });
        
    }

    assignRole(form: NgForm) {
        var formData = this.employees[0];
        formData.employeeId = this.employees[0].employeeId;
        formData.userName = this.employees[0].userName;
        formData.employeeName = this.employees[0].employeeName;
        formData.gender = this.employees[0].gender;
        formData.designation = this.employees[0].designation;
        formData.skillSet = this.employees[0].skillSet;
        formData.dob = this.employees[0].dob;
        formData.email = this.employees[0].email;
        formData.mobile = this.employees[0].mobile;
        formData.alternateNumber = this.employees[0].alternateNumber;
        formData.addressLine1 = this.employees[0].addressLine1;
        formData.addressLine2 = this.employees[0].addressLine2;
        formData.addressLine3 = this.employees[0].addressLine3;
        formData.zipCode = this.employees[0].zipCode;
        formData.country = this.employees[0].country;
        formData.state = this.employees[0].state;
        formData.fatherName = this.employees[0].fatherName;
        formData.motherName = this.employees[0].motherName;
        formData.fatherDOB = this.employees[0].fatherDOB;
        formData.motherDOB = this.employees[0].motherDOB;
        formData.signedUp = true;
        formData.emergencyContactName = this.employees[0].emergencyContactName;
        formData.emergencyContactRelation = this.employees[0].emergencyContactRelation;
        formData.emergencyContactNumber = this.employees[0].emergencyContactNumber;
        formData.emergencyContactDOB = this.employees[0].emergencyContactDOB;
        formData.reportingManager = this.employee.reportingManager;
        formData.roleName = this.role.roleName;
        console.log('Role Name:- ',
            formData.roleName + 'Manager Name:- ',
            formData.reportingManager);
        console.log(formData);
        this.roleService.assignRole(formData)
            .subscribe(e => {
                    this.toastyService.success({
                        title: 'Success',
                        msg: 'Role and Reporting Manager assigned successfully',
                        theme: 'bootstrap',
                        showClose: true,
                        timeout: 5000
                    });
                    this.router.navigate(['/']);
                },
                err => {
                    this.toastyService.error({
                        title: 'Error',
                        msg: 'An unexpected error occured while assigning the role',
                        theme: 'bootstrap',
                        showClose: true,
                        timeout: 5000
                    });
                });
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