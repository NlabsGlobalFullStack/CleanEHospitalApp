import { Injectable } from '@angular/core';
import { UserModel } from '../models/user.model';
import { Router } from '@angular/router';
import { jwtDecode, JwtPayload } from 'jwt-decode';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  token: string = "";
  user: UserModel = new UserModel();

  constructor(
    private router: Router
  ) { }

  isAuthenticated(){
    this.token = localStorage.getItem("token") ?? "";
    if(this.token === ""){
      this.router.navigateByUrl("/login");
      return false;
    }
    const decode: JwtPayload | any = jwtDecode(this.token);
    const exp = decode.exp;
    const now = new Date().getTime() / 1000;

    if (now > exp) {
      this.router.navigateByUrl("/login");
      return false;
    }

    this.user.id = decode["Id"];
    this.user.fullName = decode["Name"];
    this.user.email = decode["Email"];
    this.user.userName = decode["UserName"];
    this.user.role = decode["Role"];
    this.user.userType = decode["UserType"];
    

    return true;
  }
}
