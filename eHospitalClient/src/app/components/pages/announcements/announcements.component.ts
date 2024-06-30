import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { TitleService } from '../../../services/title.service';
import { DatePipe } from '@angular/common';
import { FormsModule, NgForm } from '@angular/forms';
import { FormValidateDirective } from 'form-validate-angular';
import { AnnouncementModel } from '../../../models/announcement.model';
import { HttpService } from '../../../services/http.service';
import { SwalService } from '../../../services/swal.service';

@Component({
  selector: 'app-announcements',
  standalone: true,
  templateUrl: './announcements.component.html',
  styleUrl: './announcements.component.css',
  imports: [DatePipe, FormsModule, FormValidateDirective]
})
export class AnnouncementsComponent implements OnInit {
  announcements: AnnouncementModel[] = [];

  @ViewChild("createModalCloseBtn") createModalCloseBtn: ElementRef<HTMLButtonElement> | undefined;
  @ViewChild("updateModalCloseBtn") updateModalCloseBtn: ElementRef<HTMLButtonElement> | undefined;

  @ViewChild("createFile") createImageEl: ElementRef<HTMLInputElement> | undefined;
  @ViewChild("updateFile") updateImageEl: ElementRef<HTMLInputElement> | undefined;

  createModel: AnnouncementModel = new AnnouncementModel();
  updateModel: AnnouncementModel = new AnnouncementModel();

  constructor(
    private title: TitleService,
    private http: HttpService,
    private swal: SwalService
  ) { }

  ngOnInit(): void {
    this.title.setPageTitle('Announcements');
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
    this.http.post<AnnouncementModel[]>("Announcements/GetAll", {}, (res) => {
      this.announcements = res;
    })
  }

  checkedStatus(id: string) {
    this.swal.callSwal("Are you sure you want to change the posting status of the recording?", "", () => {
      this.http.post<string>("Announcements/ChangeStatus?Id=", { id }, (res) => {
        this.getAll();
        this.swal.callToast(res, "warning");
      });
    })
  }

  selectFile(event: any) {
    this.createModel.file = event.target.files[0];

    if (this.createModel.file) {
      const reader = new FileReader();
      reader.onload = (e: any) => {
        this.createModel.image = e.target.result;
      };
      reader.readAsDataURL(this.createModel.file);
    }
  }

  selectUpdateFile(event: any) {
    this.updateModel.file = event.target.files[0];
  }

  clearSelectedImage() {
    this.createModel.image = "";
    this.createModel.file = null;

    this.updateModel.image = "";
    this.updateModel.file = null;

    if (this.createImageEl != undefined) {
      this.createImageEl.nativeElement.value = "";
    }
    if (this.updateImageEl != undefined) {
      this.updateImageEl.nativeElement.value = "";
    }
  }

  create(form: NgForm) {
    if (form.valid) {
      const formData = new FormData();
      if (this.createModel.file) {
        formData.append("file", this.createModel.file, this.createModel.file.name);
      }
      if (this.createModel.title) {
        formData.append("title", this.createModel.title);
      }
      if (this.createModel.summary) {
        formData.append("summary", this.createModel.summary);
      }
      if (this.createModel.content) {
        formData.append("content", this.createModel.content);
      }
      formData.append("isPublish", this.createModel.isPublish ? 'true' : 'false');

      this.http.post<string>("Announcements/Create", formData, (res) => {
        this.swal.callToast(res);
        this.createModel = new AnnouncementModel();
        this.createModalCloseBtn?.nativeElement.click();
        this.getAll();
      });
    }
  }

  get(model: AnnouncementModel) {
    this.updateModel = { ...model };
  }

  update(form: NgForm) {
    if (form.valid) {
      const updateFormData = new FormData();
      updateFormData.append("id", this.updateModel.id);
      if (this.updateModel.title) {
        updateFormData.append("name", this.updateModel.title);
      }
      if (this.updateModel.summary) {
        updateFormData.append("summary", this.updateModel.summary);
      }
      if (this.updateModel.content) {
        updateFormData.append("content", this.updateModel.content);
      }

      if (this.updateModel.file) {
        updateFormData.append("file", this.updateModel.file, this.updateModel.file.name);
      }

      updateFormData.append("isPublish", this.updateModel.isPublish ? 'true' : 'false');

      this.http.post<string>("Announcements/Update", updateFormData, (res) => {
        this.swal.callToast(res, "info");
        this.updateModalCloseBtn?.nativeElement.click();
        this.getAll();
      });
    }
  }

  deleteById(id: string) {
    this.swal.callSwal("Are you sure you want to mark the record as deleted?", "", () => {
      this.http.post<string>("Announcements/DeleteBy?Id=", { id }, (res) => {
        this.getAll();
        this.swal.callToast(res, "warning");
      });
    })
  }
}
