import { Component, OnInit } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { UserModel } from '../../../models/user.model';
import { AuthService } from '../../../services/auth.service';
import { HttpService } from '../../../services/http.service';
import { SwalService } from '../../../services/swal.service';

@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [RouterLink],
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css'
})
export class NavbarComponent implements OnInit{
  user: UserModel = new UserModel();

  constructor(
    public auth: AuthService,
    private router: Router,
    private http: HttpService
  ){}


  ngOnInit(): void {
    this.getByUser(this.auth.user.id!);
  }


  getByUser(id: string): void{    
    this.http.post<UserModel>(`Dashboard/GetByUser?Id=${id}`, {}, (res) => {
      this.user = res;      
    })
  }


  logout() {
    localStorage.clear();
    this.router.navigateByUrl("/login");
  }
}
