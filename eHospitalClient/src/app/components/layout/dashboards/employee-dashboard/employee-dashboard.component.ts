import { Component, OnInit } from '@angular/core';
import { TitleService } from '../../../../services/title.service';
import { DepartmentModel } from '../../../../models/department.model';
import { UserModel } from '../../../../models/user.model';
import { ServiceCareModel } from '../../../../models/service.model';
import { FaqModel } from '../../../../models/faq.model';
import { SliderModel } from '../../../../models/slider.model';
import { AnnouncementModel } from '../../../../models/announcement.model';
import { TableComponent } from '../../../layout/shared/table/table.component';
import { BreadcrumpComponent } from '../../../layout/shared/breadcrump/breadcrump.component';

@Component({
  selector: 'app-employee-dashboard',
  standalone: true,
  imports: [BreadcrumpComponent, TableComponent],
  templateUrl: './employee-dashboard.component.html',
  styleUrl: './employee-dashboard.component.css'
})
export class EmployeeDashboardComponent implements OnInit{
  departments: DepartmentModel[] = [];
  doctors: UserModel[] = [];
  urgentCareServices: ServiceCareModel[] = [];
  faqs: FaqModel[] = [];
  sliders: SliderModel[] = [];
  announcements: AnnouncementModel[] = [];

  
  constructor(private title: TitleService) { }

  ngOnInit(): void {
    this.title.setPageTitle('Employee Dashboard');
  }
}
