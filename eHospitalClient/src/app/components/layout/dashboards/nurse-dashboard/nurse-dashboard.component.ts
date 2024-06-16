import { Component } from '@angular/core';
import { TitleService } from '../../../../services/title.service';
import { BreadcrumpComponent } from '../../../layout/shared/breadcrump/breadcrump.component';
import { TableComponent } from '../../../layout/shared/table/table.component';

@Component({
  selector: 'app-nurse-dashboard',
  standalone: true,
  imports: [BreadcrumpComponent, TableComponent],
  templateUrl: './nurse-dashboard.component.html',
  styleUrl: './nurse-dashboard.component.css'
})
export class NurseDashboardComponent {
  constructor(private titleService: TitleService){}

  ngOnInit(): void {
    this.titleService.setPageTitle('Hemşire Dashboard');
  }
}
