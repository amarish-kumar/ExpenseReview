import { NgModule } from '@angular/core';
import { ServerModule } from '@angular/platform-server';
import { AppModuleShared } from './app.module.shared';
import { AppComponent } from './components/app/app.component';
import { EmployeeService } from './services/employee.service';
import { ExpenseService } from './services/expense.service';
import { ApproverService } from './services/approver.service';

//TODO:- URL Refresh issue needs to be fixed. Base URL needs to explored more
@NgModule({
    bootstrap: [ AppComponent ],
    imports: [
        ServerModule,
        AppModuleShared
    ],
    providers: [EmployeeService, ExpenseService, ApproverService]
})
export class AppModule {
}
