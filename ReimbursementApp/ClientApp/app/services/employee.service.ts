import { Injectable, Inject } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

@Injectable()
export class EmployeeService {
    constructor(private http: Http, @Inject('BASE_URL') private originUrl: string) { }
    
    getEmployees(){
        return this.http.get(this.originUrl + 'api/employee')
        //Once, we get the response back, it has to get mapped to json
        .map(res => res.json());
    }

    getEmployee(id) {
        return this.http.get(this.originUrl + 'api/employee/' + id)
            .map(res => res.json());
    }

    getEmployeeByName(name) {
        return this.http.get(this.originUrl + 'api/employee/GetByName/' + name)
            .map(res => res.json());
    }

    getEmployeeByDesig(desig) {
        return this.http.get(this.originUrl + 'api/employee/GetByDesignation/' + desig)
            .map(res => res.json());
    }

    getEmployeeByManager(manager) {
        return this.http.get(this.originUrl + 'api/employee/GetByManager/' + manager)
            .map(res => res.json());
    }

    submitEmployee(employee) {
        return this.http.post(this.originUrl + 'api/employee', employee)
            .map(res => res.json());
    }
}