import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppModuleShared } from './app.module.shared';
import { AppComponent } from './components/app/app.component';
import {EmployeeService } from "./components/employee/employee.service";


@NgModule({
    bootstrap: [ AppComponent ],
    imports: [
        BrowserModule,
        AppModuleShared
    ],
    providers: [
        { provide: 'BASE_URL', useFactory: getBaseUrl },
        /*{ provide: 'BASE_URL', useValue: location.origin },*/
        EmployeeService
    ]
})
export class AppModule {
}

export function getBaseUrl() {
    console.log('Location Origin:-', location.origin);
    console.log('Base URL:-', document.getElementsByTagName('base')[0].href);
    return document.getElementsByTagName('base')[0].href;
    
}
