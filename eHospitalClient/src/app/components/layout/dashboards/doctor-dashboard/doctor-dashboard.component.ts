import { Component } from '@angular/core';
import { TitleService } from '../../../../services/title.service';
import { TableComponent } from '../../../layout/shared/table/table.component';
import { BreadcrumpComponent } from '../../../layout/shared/breadcrump/breadcrump.component';

@Component({
  selector: 'app-doctor-dashboard',
  standalone: true,
  imports: [TableComponent, BreadcrumpComponent],
  templateUrl: './doctor-dashboard.component.html',
  styleUrl: './doctor-dashboard.component.css'
})
export class DoctorDashboardComponent {
  constructor(private titleService: TitleService){}

  ngOnInit(): void {
    this.titleService.setPageTitle('Doctor');
  }
}
