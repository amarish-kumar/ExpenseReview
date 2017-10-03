import { Component, OnInit, Inject, ViewChild } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Http } from '@angular/http';
import { EmployeeService } from '../../services/employee.service';
import { ApproverService } from '../../services/approver.service';
import { ToastyService } from "ng2-toasty";
import { Employee } from './../../models/employee';
import { NgForm } from '@angular/forms';


@Component({
    selector: 'app-edit-employee',
    templateUrl: './edit-employee.component.html',
    styleUrls: ['./edit-employee.component.css']

})

export class EditEmployeeComponent implements OnInit {
    employee: Employee = new Employee();
    approvers;
  

    @ViewChild('empIdInput') empIdInput;
    constructor(
        private router: Router,
        private route: ActivatedRoute,
        private employeeService: EmployeeService,
        private approverService: ApproverService,
        private toastyService: ToastyService) {
      
    }

    ngOnInit() {
        this.approverService.getApprovers()
            .subscribe(app => {
                this.approvers = app;
                console.log("Approvers",this.approvers);
            });

        this.employeeService.getEmployeeByUserName()
            .subscribe(e => {
                this.employee = e[0];
                    console.log("Employee", this.employee);
                    this.toastyService.success({
                        title: 'Success',
                        msg: 'Employee Info Retrieved Successfully!',
                        theme: 'bootstrap',
                        showClose: true,
                        timeout: 5000
                    });
                },
                err => {
                    this.toastyService.error({
                        title: 'Error',
                        msg: 'Error Occured while Fetching Details!',
                        theme: 'bootstrap',
                        showClose: true,
                        timeout: 5000
                    });
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
                        msg: 'Info Edited Successfully!',
                        theme: 'bootstrap',
                        showClose: true,
                        timeout: 5000
                    });
                },
                err => {
                    this.toastyService.error({
                        title: 'Error',
                        msg: 'An unexpected error occured while editing details!',
                        theme: 'bootstrap',
                        showClose: true,
                        timeout: 5000
                    });
                });
    }
  
}