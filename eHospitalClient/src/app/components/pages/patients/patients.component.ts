import { Component, OnInit } from '@angular/core';
import { BreadcrumpComponent } from "../../layout/shared/breadcrump/breadcrump.component";
import { TableComponent } from "../../layout/shared/table/table.component";
import { TitleService } from '../../../services/title.service';

@Component({
    selector: 'app-patients',
    standalone: true,
    templateUrl: './patients.component.html',
    styleUrl: './patients.component.css',
    imports: [BreadcrumpComponent, TableComponent]
})
export class PatientsComponent implements OnInit{

    constructor(private title: TitleService) { }

    ngOnInit(): void {
      this.title.setPageTitle('Patients');
    }
}