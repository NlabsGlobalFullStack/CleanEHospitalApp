import { Component, OnInit } from '@angular/core';
import { BreadcrumpComponent } from "../../layout/shared/breadcrump/breadcrump.component";
import { TableComponent } from "../../layout/shared/table/table.component";
import { TitleService } from '../../../services/title.service';

@Component({
    selector: 'app-departments',
    standalone: true,
    templateUrl: './departments.component.html',
    styleUrl: './departments.component.css',
    imports: [BreadcrumpComponent, TableComponent]
})
export class DepartmentsComponent implements OnInit{

    constructor(private title: TitleService) { }

    ngOnInit(): void {
      this.title.setPageTitle('Departments');
    }
}