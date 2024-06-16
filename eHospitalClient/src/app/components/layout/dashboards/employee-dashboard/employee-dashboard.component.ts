import { Component } from '@angular/core';
import { TitleService } from '../../../../services/title.service';
import { DepartmentModel } from '../../../../models/department.model';
import { UserModel } from '../../../../models/user.model';
import { UrgentCareModel } from '../../../../models/urgent-care.model';
import { QuestionModel } from '../../../../models/question.model';
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
export class EmployeeDashboardComponent {
  constructor(private titleService: TitleService) { }
  departments: DepartmentModel[] = [];
  doctors: UserModel[] = [];
  urgentCareServices: UrgentCareModel[] = [];
  questions: QuestionModel[] = [];
  sliders: SliderModel[] = [];
  announcements: AnnouncementModel[] = [];

  ngOnInit(): void {
    // this.titleService.setPrefix('NLabs eHospital |');
    this.titleService.setPageTitle('Personel');
  }
}
