import { Component, Input, OnInit } from '@angular/core';
import { TitleService } from '../../../services/title.service';
import { HttpService } from '../../../services/http.service';
import { SwalService } from '../../../services/swal.service';
import { ActivatedRoute, Router } from '@angular/router';
import { VehicleModel } from '../../../models/vehicle.model';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-vehicle-detail',
  standalone: true,
  imports: [DatePipe],
  templateUrl: './vehicle-detail.component.html',
  styleUrl: './vehicle-detail.component.css'
})
export class VehicleDetailComponent implements OnInit{
  @Input("vehicleId") vehicleId: string = '';
  vehicle: VehicleModel = new VehicleModel();

  constructor(
    private route: ActivatedRoute,
    private title: TitleService,
    private http: HttpService,
    private swal: SwalService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.title.setPageTitle('Vehicle Detail');
    this.route.paramMap.subscribe(params => {
      this.vehicleId = params.get('id')!;
      this.getById(this.vehicleId);
    });
  }

  getById(id: string) {    
    this.http.post<VehicleModel>(`Vehicles/GetById?id=${id}`, {}, (res) => {
      this.vehicle = res;
      if(res === null){
        this.router.navigateByUrl("/dashboard/vehicles");
      }
    })
  }

  deleteById(id: string) {
    this.http.post<string>("Vehicles/GetById?Id=", { id }, (res) => {
      this.swal.callToast(res, "warning");
    });
  }
}
