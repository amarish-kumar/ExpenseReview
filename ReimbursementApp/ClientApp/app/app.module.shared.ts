import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import { ToastyModule } from "ng2-toasty";

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component';
import { EmployeeComponent } from './components/employee/employee.component';
import { NewEmployeeComponent } from './components/new-employee/new-employee.component';
import { SearchEmployeeComponent } from './components/search-employee/search-employee.component';
import { NewExpenseComponent } from './components/new-expense/new-expense.component';
import { FetchExpenseComponent } from './components/fetch-expense/fetch-expense.component';
import { EmployeeService } from './services/employee.service';
import { ExpenseService } from './services/expense.service';
import { ApproverService } from './services/approver.service';


@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        CounterComponent,
        FetchDataComponent,
        HomeComponent,
        EmployeeComponent,
        NewEmployeeComponent,
        SearchEmployeeComponent,
        NewExpenseComponent,
        FetchExpenseComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        ToastyModule.forRoot(),
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'counter', component: CounterComponent },
            { path: 'fetch-data', component: FetchDataComponent },
            { path: 'employee', component: EmployeeComponent },
            { path: 'new-employee', component: NewEmployeeComponent },
            { path: 'search-employee', component: SearchEmployeeComponent },
            { path: 'new-expense', component: NewExpenseComponent },
            { path: 'fetch-expense', component: FetchExpenseComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ],
    providers: [EmployeeService, ExpenseService, ApproverService]
})
export class AppModuleShared {
}
