import { Injectable, Inject } from '@angular/core';
import { Http, Response, Headers } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

@Injectable()
export class ApproverService {
    constructor(private http: Http, @Inject('BASE_URL') private originUrl: string) { }

    getApprovers() {
        return this.http.get(this.originUrl + 'api/approverlist', { withCredentials: true })
            //Once, we get the response back, it has to get mapped to json
            .map(res => res.json());
    }

    approveEmployee(employee) {
        const body = JSON.stringify(employee);
        const headers = new Headers({ 'Content-Type': 'application/json' });
        console.log("Employee Form:", body);
        return this.http.put(this.originUrl + 'api/approver', body, { headers: headers, withCredentials: true })
            .map(res => res.json());
    }

 }