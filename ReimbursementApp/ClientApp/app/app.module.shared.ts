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
import { MyExpensesComponent } from './components/my-expenses/my-expenses.component';
import { DetailViewComponent } from './components/detail-view/detail-view.component';
import { EditExpenseComponent } from './components/edit-expense/edit-expense.component';
import { EditEmployeeComponent } from './components/edit-employee/edit-employee.component';
import { UploadDocumentComponent } from './components/upload-documents/upload-document.component';
import { EmployeeService } from './services/employee.service';
import { ExpenseService } from './services/expense.service';
import { ApproverService } from './services/approver.service';
import { ExpCategoryService } from './services/expCategory.service';
import { MenuAccessService } from './services/menuAccess.service';
import { DocsService } from './services/document.service';


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
        FetchExpenseComponent,
        MyExpensesComponent,
        DetailViewComponent,
        EditExpenseComponent,
        EditEmployeeComponent,
        UploadDocumentComponent
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
            { path: 'my-expenses', component: MyExpensesComponent },
            { path: 'detail-view/:id', component: DetailViewComponent },
            { path: 'edit-expense/:id', component: EditExpenseComponent },
            { path: 'edit-employee', component: EditEmployeeComponent },
            { path: 'upload-document/:id', component: UploadDocumentComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ],
    providers: [EmployeeService,
        ExpenseService,
        ApproverService,
        ExpCategoryService,
        MenuAccessService,
        DocsService
    ]
})
export class AppModuleShared {
}
