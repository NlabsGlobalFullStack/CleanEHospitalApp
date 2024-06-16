import { Component } from '@angular/core';
import { TitleService } from '../../../../services/title.service';
import { DepartmentModel } from '../../../../models/department.model';
import { UserModel } from '../../../../models/user.model';
import { UrgentCareModel } from '../../../../models/urgent-care.model';
import { QuestionModel } from '../../../../models/question.model';
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
  constructor(private titleService: TitleService) { }
  departments: DepartmentModel[] = [];
  users: UserModel[] = [];
  urgentCareServices: UrgentCareModel[] = [];
  questions: QuestionModel[] = [];
  sliders: SliderModel[] = [];
  announcements: AnnouncementModel[] = [];
  settings: SettingsModel | undefined;

  ngOnInit(): void {
    this.titleService.setPageTitle('Dashboard');
  }
}
