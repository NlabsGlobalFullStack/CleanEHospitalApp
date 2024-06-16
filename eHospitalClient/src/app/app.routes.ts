import { Routes } from '@angular/router';
import { HomeComponent } from './components/pages/home/home.component';
import { LoginComponent } from './components/pages/login/login.component';
import { LayoutComponent } from './components/layout/layout/layout.component';
import { NotFoundComponent } from './components/pages/not-found/not-found.component';
import { DashboardComponent } from './components/layout/dashboard/dashboard.component';
import { NurseDashboardComponent } from './components/layout/dashboards/nurse-dashboard/nurse-dashboard.component';
import { DoctorDashboardComponent } from './components/layout/dashboards/doctor-dashboard/doctor-dashboard.component';
import { AdminDashboardComponent } from './components/layout/dashboards/admin-dashboard/admin-dashboard.component';
import { EmployeeComponent } from './components/pages/employee/employee.component';
import { inject } from '@angular/core';
import { AuthService } from './services/auth.service';
import { EmployeeDashboardComponent } from './components/layout/dashboards/employee-dashboard/employee-dashboard.component';
import { DoctorsComponent } from './components/pages/doctors/doctors.component';
import { NursesComponent } from './components/pages/nurses/nurses.component';
import { EmployeesComponent } from './components/pages/employees/employees.component';
import { PatientsComponent } from './components/pages/patients/patients.component';

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
                component: DashboardComponent,
                children: [
                    {
                        path: "",
                        component: AdminDashboardComponent
                    }, 
                    {
                        path: "doctor-dashboard",
                        component: DoctorDashboardComponent
                    },                            
                    {
                        path: "nurse-dashboard",
                        component: NurseDashboardComponent
                    },
                    {
                        path: "employee-dashboard",
                        component: EmployeeDashboardComponent
                    },
                    {
                        path: "patient-dashboard",
                        component: AdminDashboardComponent
                    },
                    {
                        path: "appointments",
                        component: AdminDashboardComponent
                    },
                    {
                        path: "announcements",
                        component: AdminDashboardComponent
                    },
                    {
                        path: "departments",
                        component: AdminDashboardComponent
                    },
                    {
                        path: "rooms",
                        component: AdminDashboardComponent
                    },
                    {
                        path: "vehicles",
                        component: AdminDashboardComponent
                    },
                    {
                        path: "sss",
                        component: AdminDashboardComponent
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
                    }
                ]
            }
        ]
    },
    {
        path: "**",
        component: NotFoundComponent
    }
];
