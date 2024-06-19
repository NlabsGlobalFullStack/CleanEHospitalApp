import { Component, OnInit } from '@angular/core';
import { BreadcrumpComponent } from "../../layout/shared/breadcrump/breadcrump.component";
import { TableComponent } from "../../layout/shared/table/table.component";
import { TitleService } from '../../../services/title.service';

@Component({
    selector: 'app-vehicles',
    standalone: true,
    templateUrl: './vehicles.component.html',
    styleUrl: './vehicles.component.css',
    imports: [BreadcrumpComponent, TableComponent]
})
export class VehiclesComponent implements OnInit{

    constructor(private title: TitleService) { }

    ngOnInit(): void {
      this.title.setPageTitle('Vehicles');
    }
}
