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
    selector: 'app-pending-approval',
    templateUrl: './pending-approvals.component.html',
    styleUrls: ['./pending-approvals.component.css']

})

export class PendingApprovalComponent implements OnInit {
    employees;
    
    constructor(
        private router: Router,
        private route: ActivatedRoute,
        private employeeService: EmployeeService,
        private toastyService: ToastyService) {

    }

    
    ngOnInit() {
        this.employeeService.getPendingEmployees().subscribe(employees => {
            this.employees = employees;
            console.log("Employees:- ", this.employees);

        });
        
    }

    
}