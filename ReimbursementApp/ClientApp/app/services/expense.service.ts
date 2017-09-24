import { Injectable, Inject } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

@Injectable()
export class ExpenseService {
    constructor(private http: Http, @Inject('BASE_URL') private originUrl: string) { }

    getExpenses() {
        return this.http.get(this.originUrl + 'api/expense')
            //Once, we get the response back, it has to get mapped to json
            .map(res => res.json());
    }

    getExpenseById(id) {
        return this.http.get(this.originUrl + 'api/expense/' + id)
            .map(res => res.json());
    }

    getExpenseByName(name) {
        return this.http.get(this.originUrl + 'api/expense/GetByName/' + name)
            .map(res => res.json());
    }

    getExpenseByDesig(desig) {
        return this.http.get(this.originUrl + 'api/expense/GetByDesignation/' + desig)
            .map(res => res.json());
    }

    getExpenseByManager(manager) {
        return this.http.get(this.originUrl + 'api/expense/GetByManager/' + manager)
            .map(res => res.json());
    }
}