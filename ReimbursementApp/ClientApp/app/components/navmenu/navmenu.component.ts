import { Component, OnInit } from '@angular/core';
import { MenuAccessService } from '../../services/menuAccess.service';

@Component({
    selector: 'nav-menu',
    templateUrl: './navmenu.component.html',
    styleUrls: ['./navmenu.component.css']
    
})
export class NavMenuComponent implements OnInit {
    showhide:boolean;
    constructor(private menuAccessService: MenuAccessService) { }
    ngOnInit() {
        this.menuAccessService.checkAccess()
            .subscribe(a => {
                this.showhide = a;
                console.log("Access:- ", a);
            },err => {
                console.log('Error occured while fetching access!');
            });
    }
}
