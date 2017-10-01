import { Component, OnInit, Inject } from '@angular/core';
import { ApproverService } from '../../services/approver.service';
import { Http } from '@angular/http';
import { EmployeeService } from '../../services/employee.service';
import { NgForm } from '@angular/forms';
import { ToastyService } from "ng2-toasty";
import { Employee } from './../../models/employee';


@Component({
    selector: 'app-new-employee',
    templateUrl: './new-employee.component.html',
    styleUrls: ['./new-employee.component.css']

})

export class NewEmployeeComponent implements OnInit {
    approvers;
    employee: Employee = new Employee();
    constructor(
        private employeeService: EmployeeService,
        private approverService: ApproverService,
        private toastyService:ToastyService) { }
    
    ngOnInit() {
        //TODO:- Once empoloyee submitted, hide submi button and show edit button, based on signedUp flag
        this.approverService.getApprovers()
            .subscribe(app => {
                this.approvers = app;
            });
    }

    onSubmit(form: NgForm) {
        var formData = this.employee;
        formData.employeeId = this.employee.employeeId;
        formData.userName = this.employee.userName;
        formData.employeeName = this.employee.employeeName;
        formData.gender = this.employee.gender;
        formData.designation = this.employee.designation;
        formData.skillSet = this.employee.skillSet;
        formData.dob = this.employee.dob;
        formData.email = this.employee.email;
        formData.mobile = this.employee.mobile;
        formData.alternateNumber = this.employee.alternateNumber;
        formData.addressLine1 = this.employee.addressLine1;
        formData.addressLine2 = this.employee.addressLine2;
        formData.addressLine3 = this.employee.addressLine3;
        formData.zipCode = this.employee.zipCode;
        formData.country = this.employee.country;
        formData.state = this.employee.state;
        formData.fatherName = this.employee.fatherName;
        formData.motherName = this.employee.motherName;
        formData.fatherDob = this.employee.fatherDob;
        formData.motherDob = this.employee.motherDob;
        formData.signedUp = true;
        formData.emergencyContactName = this.employee.emergencyContactName;
        formData.emergencyContactRelation = this.employee.emergencyContactRelation;
        formData.emergencyContactNumber = this.employee.emergencyContactNumber;
        formData.emergencyContactDOB = this.employee.emergencyContactDOB;
        formData.reportingManager = this.employee.reportingManager;

        this.employeeService.submitEmployee(formData)
            .subscribe(e => {
                    this.toastyService.success({
                        title: 'Success',
                        msg: 'New Expense Created!',
                        theme: 'bootstrap',
                        showClose: true,
                        timeout: 5000
                    });
                },
                err => {
                    this.toastyService.error({
                        title: 'Error',
                        msg: 'An unexpected error occured while creating new Employee!',
                        theme: 'bootstrap',
                        showClose: true,
                        timeout: 5000
                    });
                });
    }
}