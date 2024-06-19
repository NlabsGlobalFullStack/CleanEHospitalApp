import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { TableComponent } from "../../layout/shared/table/table.component";
import { BreadcrumpComponent } from "../../layout/shared/breadcrump/breadcrump.component";
import { RouterLink } from '@angular/router';
import { FaqModel } from '../../../models/faq.model';
import { TitleService } from '../../../services/title.service';
import { HttpService } from '../../../services/http.service';
import { SwalService } from '../../../services/swal.service';
import { FormsModule, NgForm } from '@angular/forms';

@Component({
    selector: 'app-faqs',
    standalone: true,
    templateUrl: './faqs.component.html',
    styleUrl: './faqs.component.css',
    imports: [TableComponent, BreadcrumpComponent, RouterLink, FormsModule]
})
export class FaqsComponent implements OnInit{
    faqs: FaqModel[] = [];
    p: number = 1;

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

    deleteById(model: FaqModel) {
        this.swal.callSwal("", `${model.question}`, () => {
            this.http.post<string>("Faqs/MarkedAsDeleted", { id: model }, (res) => {
                this.getAll();
                this.swal.callToast(res, "info");
            });
        })
    }

    get(model: FaqModel) {
        this.updateModel = { ...model };
    }

    update(form: NgForm) {
        if (form.valid) {
            this.http.post<string>("Faqs/Update", this.updateModel, (res) => {
                this.swal.callToast(res, "info");
                this.updateModalCloseBtn?.nativeElement.click();
                this.getAll();
            });
        }
    }

    undoDeletionById(model: FaqModel) {
        this.swal.callSwal("", `${model.question}`, () => {
            this.http.post<string>("Faqs/UndoDeletionById", { id: model }, (res) => {
                this.getAll();
                this.swal.callToast(res, "success");
            });
        })
    }
}
