import { Component, OnInit } from '@angular/core';
import { MenuAccessService } from '../../services/menuAccess.service';
import { EmployeeService } from '../../services/employee.service';

@Component({
    selector: 'nav-menu',
    templateUrl: './navmenu.component.html',
    styleUrls: ['./navmenu.component.css']
    
})
export class NavMenuComponent implements OnInit {
    showhide: boolean;
    signedUp:boolean;
    constructor(
        private menuAccessService: MenuAccessService,
        private employeeService: EmployeeService) { }

    ngOnInit() {
        this.menuAccessService.checkAccess()
            .subscribe(a => {
                this.showhide = a;
                console.log("Access:- ", a);
            },err => {
                console.log('Error occured while fetching access!');
            });

        this.employeeService.checkLoginStatus()
            .subscribe(status => {
                this.signedUp = status;
            },err => {
                console.log("Error Occured, while fetching status!");
            });
    }
}
