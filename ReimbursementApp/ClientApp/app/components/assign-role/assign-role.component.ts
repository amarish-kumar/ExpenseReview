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

    constructor(
        private router: Router,
        private route: ActivatedRoute,
        private employeeService: EmployeeService,
        private approverService:ApproverService,
        private roleService: AssignRoleService,
        private toastyService: ToastyService) {

    }

    ngOnInit() {
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

        this.employeeService.getEmployeeByUserName()
            .subscribe(e => {
                    this.employee = e[0];
                    console.log('Fetched Deatils:- ', this.employee);
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

    
}