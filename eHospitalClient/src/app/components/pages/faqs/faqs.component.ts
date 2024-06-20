import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { TableComponent } from "../../layout/shared/table/table.component";
import { BreadcrumpComponent } from "../../layout/shared/breadcrump/breadcrump.component";
import { RouterLink } from '@angular/router';
import { FaqModel } from '../../../models/faq.model';
import { TitleService } from '../../../services/title.service';
import { HttpService } from '../../../services/http.service';
import { SwalService } from '../../../services/swal.service';
import { FormsModule, NgForm } from '@angular/forms';
import { DatePipe } from '@angular/common';
import { FormValidateDirective } from 'form-validate-angular';

@Component({
    selector: 'app-faqs',
    standalone: true,
    templateUrl: './faqs.component.html',
    styleUrl: './faqs.component.css',
    imports: [TableComponent, BreadcrumpComponent, RouterLink, FormsModule, DatePipe, FormValidateDirective]
})
export class FaqsComponent implements OnInit {
    faqs: FaqModel[] = [];


    @ViewChild("createModalCloseBtn") createModalCloseBtn: ElementRef<HTMLButtonElement> | undefined;
    @ViewChild("updateModalCloseBtn") updateModalCloseBtn: ElementRef<HTMLButtonElement> | undefined;

    createModel: FaqModel = new FaqModel();
    updateModel: FaqModel = new FaqModel();

    constructor(
        private title: TitleService,
        private http: HttpService,
        private swal: SwalService
    ) { }

    ngOnInit(): void {
        this.title.setPageTitle("Faqs");
        this.getAll();
        this.setCurrentDate();
    }

    setCurrentDate(): void {
        const today = new Date();
        const year = today.getFullYear();
        const month = (today.getMonth() + 1).toString().padStart(2, '0');
        const day = today.getDate().toString().padStart(2, '0');
        this.createModel.publishDate = `${year}-${month}-${day}`;
      }

    checkStatus() { 
        this.createModel.isPublish = !this.createModel.isPublish;
        this.updateModel.isPublish = !this.updateModel.isPublish;        
    }

    getAll() {
        this.http.post<FaqModel[]>("Faqs/GetAll", {}, (res) => {
            this.faqs = res;
        })
    }

    create(form: NgForm) {
        if (form.valid) {
            this.http.post<string>("Faqs/Create", this.createModel, (res) => {
                this.swal.callToast(res);
                this.createModel = new FaqModel();
                this.createModalCloseBtn?.nativeElement.click();
                this.getAll();
            });
        }
    }

    get(model: FaqModel) {
        this.updateModel = { ...model };
    }

    update(form: NgForm) {
        console.log(form);        
        if (form.valid) {
            this.http.post<string>("Faqs/Update", this.updateModel, (res) => {
                this.swal.callToast(res, "info");
                this.updateModalCloseBtn?.nativeElement.click();
                this.getAll();
            });
        }
    }

    deleteById1(model: FaqModel) {
        this.swal.callSwal("Are you sure you want to mark the record as deleted?", `${model.question}`, () => {
            this.http.post<string>("Faqs/DeleteById", { model }, (res) => {
                this.getAll();
                this.swal.callToast(res, "warning");
            });
        })
    }

    deleteById(id: string) {
        this.swal.callSwal("Are you sure you want to mark the record as deleted?", "", () => {
            this.http.post<string>("Faqs/DeleteBy?Id=", { id }, (res) => {
                this.getAll();
                this.swal.callToast(res, "warning");
            });
        })
    }
}
