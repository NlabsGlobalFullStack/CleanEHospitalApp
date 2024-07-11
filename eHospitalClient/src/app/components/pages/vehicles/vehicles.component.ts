import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { TitleService } from '../../../services/title.service';
import { HttpService } from '../../../services/http.service';
import { SwalService } from '../../../services/swal.service';
import { FormsModule, NgForm } from '@angular/forms';
import { DatePipe } from '@angular/common';
import { FormValidateDirective } from 'form-validate-angular';
import { DepartmentModel } from '../../../models/department.model';
import { vehicleTypes } from '../../../constants';
import { VehicleModel } from '../../../models/vehicle.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-vehicles',
  standalone: true,
  templateUrl: './vehicles.component.html',
  styleUrl: './vehicles.component.css',
  imports: [FormsModule, DatePipe, FormValidateDirective]
})
export class VehiclesComponent implements OnInit {
  constructor(
    private title: TitleService,
    private http: HttpService,
    private swal: SwalService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.title.setPageTitle('Vehicles');
    this.getAll();
  }

  vehicles: VehicleModel[] = [];
  vehicleTypes = vehicleTypes;


  departments: DepartmentModel[] = [];

  @ViewChild("createModalCloseBtn") createModalCloseBtn: ElementRef<HTMLButtonElement> | undefined;
  @ViewChild("updateModalCloseBtn") updateModalCloseBtn: ElementRef<HTMLButtonElement> | undefined;

  @ViewChild("createFile") createImageEl: ElementRef<HTMLInputElement> | undefined;
  @ViewChild("updateFile") updateImageEl: ElementRef<HTMLInputElement> | undefined;

  createModel: VehicleModel = new VehicleModel();
  updateModel: VehicleModel = new VehicleModel();

  getAll() {
    this.http.post<VehicleModel[]>("Vehicles/GetAll", {}, (res) => {
      this.vehicles = res;
    })
  }

  create(form: NgForm) {
    if (form.valid) {
      this.http.post<string>("Vehicles/Create", this.createModel, (res) => {
        this.swal.callToast(res);
        this.createModel = new VehicleModel();
        this.createModalCloseBtn?.nativeElement.click();
        this.getAll();
      });
    }
  }

  get(model: VehicleModel) {
    this.updateModel = { ...model };
  }

  update(form: NgForm) {    
    if (form.valid) {
      this.updateModel.vehicleTypeValue = this.updateModel.vehicleTypeValue;
      this.http.post<string>("Vehicles/Update", this.updateModel, (res) => {
        this.swal.callToast(res, "info");
        this.updateModalCloseBtn?.nativeElement.click();
        this.getAll();
      });
    }
  }

  deleteById(id: string) {
    this.swal.callSwal("Are you sure you want to mark the record as deleted?", "", () => {
      this.http.post<string>("Vehicles/DeleteBy?Id=", { id }, (res) => {
        this.getAll();
        this.swal.callToast(res, "warning");
      });
    })
  }

  getById(id: string) {
    this.http.post<string>(`Vehicles/GetById?id=${id}`, "", (res) => {
      this.swal.callToast(res, "warning");
      if(res !== null){
        this.router.navigate(['/dashboard/vehicle-detail', id]);
        // this.router.navigateByUrl(`/dashboard/vehicle-detail/${id}`);
      }
    });
  }

}