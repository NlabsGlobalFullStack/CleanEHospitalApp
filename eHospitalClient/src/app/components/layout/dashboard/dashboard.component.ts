import { Component, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { NavbarComponent } from '../navbar/navbar.component';
import { DashboardFooterComponent } from '../dashboard-footer/dashboard-footer.component';
import { UserModel } from '../../../models/user.model';
import { AuthService } from '../../../services/auth.service';
import { HttpService } from '../../../services/http.service';
import { AdminDashboardComponent } from '../dashboards/admin-dashboard/admin-dashboard.component';
import { DoctorDashboardComponent } from '../dashboards/doctor-dashboard/doctor-dashboard.component';
import { NurseDashboardComponent } from '../dashboards/nurse-dashboard/nurse-dashboard.component';
import { EmployeeDashboardComponent } from '../dashboards/employee-dashboard/employee-dashboard.component';
import { PatientDashboardComponent } from '../dashboards/patient-dashboard/patient-dashboard.component';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [
    RouterOutlet,
    NavbarComponent,
    DashboardFooterComponent,
    AdminDashboardComponent,
    DoctorDashboardComponent,
    NurseDashboardComponent,
    EmployeeDashboardComponent,
    PatientDashboardComponent
  ],
  template: `
    @if (user.userType === 0) {
      <app-admin-dashboard></app-admin-dashboard>
    }
    @if (user.userType === 1) {
      <app-doctor-dashboard></app-doctor-dashboard>
    }
    @if (user.userType === 2) {
      <app-nurse-dashboard></app-nurse-dashboard>
    }
    @if (user.userType === 3) {
      <app-employee-dashboard></app-employee-dashboard>
    }
    @if (user.userType === 4) {
      <app-patient-dashboard></app-patient-dashboard>
    }
  `
})
export class DashboardComponent implements OnInit {
  user: UserModel = new UserModel();

  constructor(
    public auth: AuthService,
    private http: HttpService
  ) { }

  ngOnInit(): void {
    this.getByUser(this.auth.user.id!);
  }

  getByUser(id: string): void {
    this.http.post<UserModel>(`Dashboard/GetByUser?Id=${id}`, {}, (res) => {
      this.user = res;
    })
  }
}
