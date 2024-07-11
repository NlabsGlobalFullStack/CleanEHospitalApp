import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { TitleService } from '../../../services/title.service';
import { DatePipe } from '@angular/common';
import { FormsModule, NgForm } from '@angular/forms';
import { FormValidateDirective } from 'form-validate-angular';
import { HttpService } from '../../../services/http.service';
import { SwalService } from '../../../services/swal.service';
import { SliderModel } from '../../../models/slider.model';

@Component({
  selector: 'app-sliders',
  standalone: true,
  templateUrl: './sliders.component.html',
  styleUrl: './sliders.component.css',
  imports: [DatePipe, FormsModule, FormValidateDirective]
})
export class SlidersComponent implements OnInit {
  sliders: SliderModel[] = [];

  @ViewChild("createModalCloseBtn") createModalCloseBtn: ElementRef<HTMLButtonElement> | undefined;
  @ViewChild("updateModalCloseBtn") updateModalCloseBtn: ElementRef<HTMLButtonElement> | undefined;

  @ViewChild("createFile") createImageEl: ElementRef<HTMLInputElement> | undefined;
  @ViewChild("updateFile") updateImageEl: ElementRef<HTMLInputElement> | undefined;

  createModel: SliderModel = new SliderModel();
  updateModel: SliderModel = new SliderModel();

  constructor(
    private title: TitleService,
    private http: HttpService,
    private swal: SwalService
  ) { }

  ngOnInit(): void {
    this.title.setPageTitle('Sliders');
    this.getAll();
  }

  getAll() {
    this.http.post<SliderModel[]>("Sliders/GetAll", {}, (res) => {
      this.sliders = res;
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
      if (this.createModel.description) {
        formData.append("description", this.createModel.description);

        this.http.post<string>("Sliders/Create", formData, (res) => {
          this.swal.callToast(res);
          this.createModel = new SliderModel();
          this.createModalCloseBtn?.nativeElement.click();
          this.getAll();
        });
      }
    }
  }

  get(model: SliderModel) {
    this.updateModel = { ...model };
  }

  update(form: NgForm) {
    if (form.valid) {
      const updateFormData = new FormData();
      updateFormData.append("id", this.updateModel.id);
      if (this.updateModel.title) {
        updateFormData.append("title", this.updateModel.title);
      }
      if (this.updateModel.description) {
        updateFormData.append("description", this.updateModel.description);
      }

      if (this.updateModel.file) {
        updateFormData.append("file", this.updateModel.file, this.updateModel.file.name);
      }

      this.http.post<string>("Sliders/Update", updateFormData, (res) => {
        this.swal.callToast(res, "info");
        this.updateModalCloseBtn?.nativeElement.click();
        this.getAll();
      });
    }
  }

  deleteById(id: string) {
    this.swal.callSwal("Are you sure you want to mark the record as deleted?", "TEST", () => {
      this.http.post<string>(`Sliders/DeleteBy?id=${id}`, "", (res) => {
        this.getAll();
        this.swal.callToast(res, "warning");
      });
    })
  }
}
