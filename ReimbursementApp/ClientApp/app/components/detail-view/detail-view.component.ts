import { Component, OnInit, Inject, ViewChild } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Http } from '@angular/http';
import { ExpenseService } from '../../services/expense.service';
import { DocsService } from '../../services/document.service';
import { ToastyService } from "ng2-toasty";
import { Expense } from './../../models/expense';
import { NgForm } from '@angular/forms';
import { SafeResourceUrl, DomSanitizer } from '@angular/platform-browser';

@Component({
    selector: 'app-detail-view',
    templateUrl: './detail-view.component.html',
    styleUrls: ['./detail-view.component.css']

})

export class DetailViewComponent implements OnInit {
    expenses;
    docs: any[] = [];
    pdfs: any[] = [];
    expense: Expense = new Expense();
    constructor(private router: Router,
        private route: ActivatedRoute,
        private expenseService: ExpenseService,
        private toastyService: ToastyService,
        private docService: DocsService,
        private sanitizer: DomSanitizer, @Inject('BASE_URL') private originUrl: string) {

        route.params.subscribe(p => {
            this.expense.expenseId = +p['id'];
        });
    }

    ngOnInit() {
        this.docService.getDocs(this.expense.expenseId)
            .subscribe(doc => {
                for (var i = 0; i < doc[0].length; i++) {
                    if (doc[0][i].docName.endsWith(".pdf")) {
                        //PDFs Collection
                        doc[0][i].docName = this.sanitizer.bypassSecurityTrustResourceUrl(this.originUrl + '/uploads/' + doc[0][i].docName);
                        this.pdfs.push(doc[0][i]);

                    } else {
                        //Images Collection
                        doc[0][i].docName = this.sanitizer.bypassSecurityTrustResourceUrl(this.originUrl + '/uploads/' + doc[0][i].docName);
                        this.docs.push(doc[0][i]);

                    }
                }

            }, err => {
                console.log("Error Occured while fetching docs!");
            });
        this.expenseService.getExpenseById(this.expense.expenseId)
            .subscribe(e => {
                    //Since, I am sending the component back as querable data from server.
                    //But, in case of ID, it will be only one.
                    this.expenses = e[0];
                    this.toastyService.success({
                        title: 'Success',
                        msg: 'Expense retieved successfully!',
                        theme: 'bootstrap',
                        showClose: true,
                        timeout: 5000
                    });
                },
                err => {
                    this.toastyService.error({
                        title: 'Error',
                        msg: 'Error Occured while Fetching Expenses!',
                        theme: 'bootstrap',
                        showClose: true,
                        timeout: 5000
                    });
                });
    }



}