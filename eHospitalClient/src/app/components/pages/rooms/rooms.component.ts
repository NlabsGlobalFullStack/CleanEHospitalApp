import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { TitleService } from '../../../services/title.service';
import { HttpService } from '../../../services/http.service';
import { SwalService } from '../../../services/swal.service';
import { RoomModel } from '../../../models/room.model';
import { FormsModule, NgForm } from '@angular/forms';
import { DatePipe } from '@angular/common';
import { FormValidateDirective } from 'form-validate-angular';
import { DepartmentModel } from '../../../models/department.model';

@Component({
  selector: 'app-rooms',
  standalone: true,
  templateUrl: './rooms.component.html',
  styleUrl: './rooms.component.css',
  imports: [FormsModule, DatePipe, FormValidateDirective]
})
export class RoomsComponent implements OnInit {
  constructor(
    private title: TitleService,
    private http: HttpService,
    private swal: SwalService
  ) { }

  ngOnInit(): void {
    this.title.setPageTitle('Rooms');
    this.getAll();
    this.getDepartments();
  }

  rooms: RoomModel[] = [];

  departments: DepartmentModel[] = [];

  @ViewChild("createModalCloseBtn") createModalCloseBtn: ElementRef<HTMLButtonElement> | undefined;
  @ViewChild("updateModalCloseBtn") updateModalCloseBtn: ElementRef<HTMLButtonElement> | undefined;

  @ViewChild("createFile") createImageEl: ElementRef<HTMLInputElement> | undefined;
  @ViewChild("updateFile") updateImageEl: ElementRef<HTMLInputElement> | undefined;

  createModel: RoomModel = new RoomModel();
  updateModel: RoomModel = new RoomModel();

  getAll() {
    this.http.post<RoomModel[]>("Rooms/GetAll", {}, (res) => {
      this.rooms = res;
      if (this.rooms.length > 0) {
        this.updateModel.roomTypeValue = this.rooms[0].roomType!.value;
        this.updateModel.departmentId = this.rooms[0].departmentId;
      }
    })
  }

  getDepartments() {
    this.http.post<DepartmentModel[]>("Departments/GetAll", {}, (res) => {
      this.departments = res;
    })
  }

  checkIsOccupied() {
    this.createModel.isOccupied = !this.createModel.isOccupied;
    this.updateModel.isOccupied = !this.updateModel.isOccupied;
  }

  checkIsOutOfService() {
    this.createModel.isOutOfService = !this.createModel.isOutOfService;
    this.updateModel.isOutOfService = !this.updateModel.isOutOfService;
  }

  create(form: NgForm) {
    if (form.valid) {
      this.http.post<string>("Rooms/Create", this.createModel, (res) => {
        this.swal.callToast(res);
        this.createModel = new RoomModel();
        this.createModalCloseBtn?.nativeElement.click();
        this.getAll();
      });
    }
  }

  get(model: RoomModel) {
    this.updateModel = { ...model };
  }

  update(form: NgForm) {
    if (form.valid) {
      this.http.post<string>("Rooms/Update", this.updateModel, (res) => {
        this.swal.callToast(res, "info");
        this.updateModalCloseBtn?.nativeElement.click();
        this.getAll();
      });
    }
  }

  deleteById(id: string) {
    this.swal.callSwal("Are you sure you want to mark the record as deleted?", "", () => {
      this.http.post<string>("Rooms/DeleteBy?Id=", { id }, (res) => {
        this.getAll();
        this.swal.callToast(res, "warning");
      });
    })
  }

}