import { Component, OnInit } from '@angular/core';
import { BreadcrumpComponent } from "../../layout/shared/breadcrump/breadcrump.component";
import { TableComponent } from "../../layout/shared/table/table.component";
import { TitleService } from '../../../services/title.service';

@Component({
    selector: 'app-employees',
    standalone: true,
    templateUrl: './employees.component.html',
    styleUrl: './employees.component.css',
    imports: [BreadcrumpComponent, TableComponent]
})
export class EmployeesComponent implements OnInit{

    constructor(private title: TitleService) { }

    ngOnInit(): void {
      this.title.setPageTitle('Employees');
    }
}
