import { Injectable, Inject } from '@angular/core';
import { Http } from '@angular/http';

@Injectable()
export class DocsService {

    constructor(private http: Http, @Inject('BASE_URL') private originUrl: string) { }

    upload(Id, doc) {
        var formData = new FormData();
        formData.append('file', doc);
        return this.http.post(this.originUrl+`api/expense/${Id}/files`, formData,  { withCredentials: true })
            .map(res => res.json());
    }

    getDocs(Id) {
        return this.http.get(this.originUrl +`api/expense/${Id}/files`, { withCredentials: true })
            .map(res => res.json());
    }
}
