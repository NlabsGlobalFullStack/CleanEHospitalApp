import { Component, OnInit } from '@angular/core';
import { BreadcrumpComponent } from "../../layout/shared/breadcrump/breadcrump.component";
import { TableComponent } from "../../layout/shared/table/table.component";
import { TitleService } from '../../../services/title.service';

@Component({
    selector: 'app-appointments',
    standalone: true,
    templateUrl: './appointments.component.html',
    styleUrl: './appointments.component.css',
    imports: [BreadcrumpComponent, TableComponent]
})
export class AppointmentsComponent implements OnInit{

    constructor(private title: TitleService) { }

    ngOnInit(): void {
      this.title.setPageTitle('Appointments');
    }
}
