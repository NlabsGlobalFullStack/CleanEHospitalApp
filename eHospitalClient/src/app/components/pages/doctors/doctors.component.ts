import { Component } from '@angular/core';
import { BreadcrumpComponent } from "../../layout/shared/breadcrump/breadcrump.component";
import { TableComponent } from "../../layout/shared/table/table.component";
import { TitleService } from '../../../services/title.service';

@Component({
    selector: 'app-doctors',
    standalone: true,
    templateUrl: './doctors.component.html',
    styleUrl: './doctors.component.css',
    imports: [BreadcrumpComponent, TableComponent]
})
export class DoctorsComponent {
    constructor(private title: TitleService) { }

    ngOnInit(): void {
        this.title.setPageTitle('Doctors');
    }
}
