import { Component } from '@angular/core';
import { TitleService } from '../../../../services/title.service';
import { TableComponent } from '../../../layout/shared/table/table.component';
import { BreadcrumpComponent } from '../../../layout/shared/breadcrump/breadcrump.component';

@Component({
  selector: 'app-patient-dashboard',
  standalone: true,
  imports: [TableComponent, BreadcrumpComponent],
  templateUrl: './patient-dashboard.component.html',
  styleUrl: './patient-dashboard.component.css'
})
export class PatientDashboardComponent {
  constructor(private title: TitleService){}

  ngOnInit(): void {
    this.title.setPageTitle('Patient Dashboard');
  }
}
