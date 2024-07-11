import { Routes } from '@angular/router';
import { HomeComponent } from './components/pages/home/home.component';
import { LoginComponent } from './components/pages/login/login.component';
import { LayoutComponent } from './components/layout/layout/layout.component';
import { NotFoundComponent } from './components/pages/not-found/not-found.component';
import { DashboardComponent } from './components/layout/dashboard/dashboard.component';
import { inject } from '@angular/core';
import { AuthService } from './services/auth.service';
import { DoctorsComponent } from './components/pages/doctors/doctors.component';
import { NursesComponent } from './components/pages/nurses/nurses.component';
import { EmployeesComponent } from './components/pages/employees/employees.component';
import { PatientsComponent } from './components/pages/patients/patients.component';
import { FaqsComponent } from './components/pages/faqs/faqs.component';
import { AppointmentsComponent } from './components/pages/appointments/appointments.component';
import { AnnouncementsComponent } from './components/pages/announcements/announcements.component';
import { DepartmentsComponent } from './components/pages/departments/departments.component';
import { RoomsComponent } from './components/pages/rooms/rooms.component';
import { VehiclesComponent } from './components/pages/vehicles/vehicles.component';
import { SlidersComponent } from './components/pages/sliders/sliders.component';
import { VehicleDetailComponent } from './components/pages/vehicle-detail/vehicle-detail.component';

export const routes: Routes = [
    {
        path: "",
        component: HomeComponent
    },
    {
        path: "login",
        component: LoginComponent
    },
    {
        path: "dashboard",
        component: LayoutComponent,
        canActivateChild: [() => inject(AuthService).isAuthenticated()],
        children: [
            {
                path: "",
                component: DashboardComponent
            },
            {
                path: "doctors",
                component: DoctorsComponent
            },
            {
                path: "nurses",
                component: NursesComponent
            },
            {
                path: "employees",
                component: EmployeesComponent
            },
            {
                path: "patients",
                component: PatientsComponent
            },
            {
                path: "appointments",
                component: AppointmentsComponent
            },
            {
                path: "announcements",
                component: AnnouncementsComponent
            },
            {
                path: "departments",
                component: DepartmentsComponent
            },
            {
                path: "rooms",
                component: RoomsComponent
            },
            {
                path: "vehicles",
                component: VehiclesComponent
            },
            {
                path: "vehicle-detail/:id",
                component: VehicleDetailComponent
            },
            {
                path: "faqs",
                component: FaqsComponent
            },
            {
                path: "sliders",
                component: SlidersComponent
            }
        ]
    },
    {
        path: "**",
        component: NotFoundComponent
    }
];
