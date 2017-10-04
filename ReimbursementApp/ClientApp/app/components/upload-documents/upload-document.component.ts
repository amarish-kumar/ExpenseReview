import { Component, OnInit, Inject, ViewChild, ElementRef } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Http } from '@angular/http';
import { ExpenseService } from '../../services/expense.service';
import { ExpCategoryService } from '../../services/expCategory.service';
import { DocsService } from '../../services/document.service';
import { ToastyService } from "ng2-toasty";
import { Expense } from './../../models/expense';
import { NgForm } from '@angular/forms';

@Component({
    selector: 'app-upload-document',
    templateUrl: './upload-document.component.html',
    styleUrls: ['./upload-document.component.css']

})
export class UploadDocumentComponent implements OnInit {
    expenses;
    showHide: boolean;
    expCategories;
    expense: Expense = new Expense();
    docs: any[];
    @ViewChild('fileInput') fileInput: ElementRef;
    

    constructor(private router: Router,
        private route: ActivatedRoute,
        private expenseService: ExpenseService,
        private toastyService: ToastyService,
        private expCategoryService: ExpCategoryService,
        private docService: DocsService) {

        route.params.subscribe(p => {
            this.expense.expenseId = +p['id'];
        });
        this.showHide = false;
    }

    ngOnInit() {

    }

    uploadDocs() {
        var nativeElement: HTMLInputElement = this.fileInput.nativeElement;

        this.docService.upload(this.expense.expenseId, nativeElement.files[0])
            .subscribe(doc => {
               // this.docs.push(doc);
                this.toastyService.success({
                    title: 'Success',
                    msg: 'File(s) Uploaded!',
                    theme: 'bootstrap',
                    showClose: true,
                    timeout: 5000
                });
            },err => {
                this.toastyService.error({
                    title: 'Error',
                    msg: 'Error Ocuured while uploading file(s).',
                    theme: 'bootstrap',
                    showClose: true,
                    timeout: 5000
                });
            });


    }
}