import { Component } from '@angular/core';
import { TitleService } from '../../../../services/title.service';
import { DepartmentModel } from '../../../../models/department.model';
import { UserModel } from '../../../../models/user.model';
import { ServiceCareModel } from '../../../../models/service.model';
import { FaqModel } from '../../../../models/faq.model';
import { SliderModel } from '../../../../models/slider.model';
import { AnnouncementModel } from '../../../../models/announcement.model';
import { SettingsModel } from '../../../../models/settings.model';
import { TableComponent } from '../../../layout/shared/table/table.component';
import { BreadcrumpComponent } from '../../../layout/shared/breadcrump/breadcrump.component';

@Component({
  selector: 'app-admin-dashboard',
  standalone: true,
  imports: [TableComponent, BreadcrumpComponent],
  templateUrl: './admin-dashboard.component.html',
  styleUrl: './admin-dashboard.component.css'
})
export class AdminDashboardComponent {
  departments: DepartmentModel[] = [];
  users: UserModel[] = [];
  services: ServiceCareModel[] = [];
  faqs: FaqModel[] = [];
  sliders: SliderModel[] = [];
  announcements: AnnouncementModel[] = [];
  settings: SettingsModel | undefined;

  
  constructor(private title: TitleService) { }

  ngOnInit(): void {
    this.title.setPageTitle('Dashboard');
  }
}
