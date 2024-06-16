import { Component, OnInit } from '@angular/core';
import { Router, RouterOutlet } from '@angular/router';
import { NavbarComponent } from '../navbar/navbar.component';
import { DashboardFooterComponent } from '../dashboard-footer/dashboard-footer.component';
import { UserModel } from '../../../models/user.model';
import { AuthService } from '../../../services/auth.service';
import { HttpService } from '../../../services/http.service';
import { SwalService } from '../../../services/swal.service';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [RouterOutlet, NavbarComponent, DashboardFooterComponent],
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.css'
})
export class DashboardComponent implements OnInit{
  user: UserModel = new UserModel();

  constructor(
    public auth: AuthService,
    private router: Router,
    private http: HttpService,
    private swal: SwalService
  ){}


  ngOnInit(): void {
    this.getByUser(this.auth.user.id!);
  }


  getByUser(id: string): void{    
    this.http.post<UserModel>(`Dashboard/GetByUser?Id=${id}`, {}, (res) => {
      this.user = res; 
      this.swal.callToast(`Welcome, We wish you a healthy day Dear: ${res.fullName}`, "success"); 
      
      if(res.userType === 0){
        this.router.navigateByUrl("/dashboard");
      }

      if(res.userType === 1){
        this.router.navigateByUrl("/doctor-dashboard");
      } 
        
      if(res.userType === 2){
        this.router.navigateByUrl("/nurse-dashboard");
      } 

      if(res.userType === 3){
        this.router.navigateByUrl("/employee-dashboard");
      } 

      if(res.userType === 4){
        this.router.navigateByUrl("/patient-dashboard");
      } 
      
    })
  }
}
