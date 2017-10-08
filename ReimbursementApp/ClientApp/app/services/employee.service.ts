import { Injectable, Inject } from '@angular/core';
import { Http, Response, Headers } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

@Injectable()
export class EmployeeService {
    constructor(private http: Http, @Inject('BASE_URL') private originUrl: string) { }
    
    getEmployees(){
        return this.http.get(this.originUrl + 'api/employee', { withCredentials: true })
        //Once, we get the response back, it has to get mapped to json
        .map(res => res.json());
    }

    getEmployee(id) {
        return this.http.get(this.originUrl + 'api/employee/' + id, { withCredentials: true })
            .map(res => res.json());
    }

    getEmployeeByName(name) {
        return this.http.get(this.originUrl + 'api/employee/GetByName/' + name, { withCredentials: true })
            .map(res => res.json());
    }

    getEmployeeByUserName() {
        return this.http.get(this.originUrl + 'api/employee/GetByUserName/', { withCredentials: true })
            .map(res => res.json());
    }

    checkLoginStatus() {
        return this.http.get(this.originUrl + 'api/employee/CheckUserLoginStatus/', { withCredentials: true })
            .map(res => res.json());
    }

    getEmployeeByDesig(desig) {
        return this.http.get(this.originUrl + 'api/employee/GetByDesignation/' + desig, { withCredentials: true })
            .map(res => res.json());
    }

    getEmployeeList() {
        return this.http.get(this.originUrl + 'api/employee/GetEmplNames/', { withCredentials: true })
            .map(res => res.json());
    }

    editEmployee(employee) {
        const body = JSON.stringify(employee);
        const headers = new Headers({ 'Content-Type': 'application/json' });
        return this.http.put(this.originUrl + 'api/employee/', body, { headers: headers,withCredentials:true })
            .map(res => res.json());
    }

    getEmployeeByManager(manager) {
        return this.http.get(this.originUrl + 'api/employee/GetByManager/' + manager, { withCredentials: true })
            .map(res => res.json());
    }

    submitEmployee(employee) {
        return this.http.post(this.originUrl + 'api/employee', employee, { withCredentials: true })
            .map(res => res.json());
    }
    
}