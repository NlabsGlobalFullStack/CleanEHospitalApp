import { Component, OnInit } from '@angular/core';
import { LoginModel } from '../../../models/login.model';
import { HttpService } from '../../../services/http.service';
import { Router } from '@angular/router';
import { LoginResponseModel } from '../../../models/login-response.model';
import { TitleService } from '../../../services/title.service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { AuthService } from '../../../services/auth.service';
import { SwalService } from '../../../services/swal.service';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent implements OnInit{
  model: LoginModel = new LoginModel();
  inputType: string = 'password';

  constructor(
    private http: HttpService,
    private router: Router,
    private title: TitleService,
    private auth: AuthService,    
    private swal: SwalService
  ) { }


  ngOnInit(): void {
    this.title.setPageTitle("Login Page");
    if(this.auth.isAuthenticated()){
      this.router.navigateByUrl("/dashboard");
    }
    else{
      return
    }
    this.title.setPageTitle("Login Page");
  }

  togglePasswordVisibility() {
    this.inputType = this.inputType === 'password' ? 'text' : 'password';
  }

  logout() {
    localStorage.clear();
    this.router.navigateByUrl("/login");
  }

  signIn() {
    this.http.post<LoginResponseModel>("Auth/Login", this.model, (res) => {
      localStorage.setItem("token", res.token);      
      this.swal.callToast("We wish you a successful login and a healthy day.", "success");
      this.router.navigateByUrl("/dashboard");
    });
  }
}
