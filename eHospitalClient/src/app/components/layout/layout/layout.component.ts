import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { NavbarComponent } from "../navbar/navbar.component";
import { DashboardFooterComponent } from "../dashboard-footer/dashboard-footer.component";

@Component({
  selector: 'app-layout',
  standalone: true,
  template: `
    <body data-bs-theme="dark">
      <div>
          <div class="page">
              <div class="page-wrapper">
                  <app-navbar></app-navbar>
                  <router-outlet></router-outlet>
                  <app-dashboard-footer></app-dashboard-footer>
              </div>
          </div>
      </div>
    </body>
  `,
  imports: [RouterOutlet, NavbarComponent, DashboardFooterComponent]
})
export class LayoutComponent { }
