import { Component, OnInit } from '@angular/core';
import { TableComponent } from "../../layout/shared/table/table.component";
import { BreadcrumpComponent } from "../../layout/shared/breadcrump/breadcrump.component";
import { TitleService } from '../../../services/title.service';

@Component({
    selector: 'app-rooms',
    standalone: true,
    templateUrl: './rooms.component.html',
    styleUrl: './rooms.component.css',
    imports: [TableComponent, BreadcrumpComponent]
})
export class RoomsComponent implements OnInit{

    constructor(private title: TitleService) { }

    ngOnInit(): void {
      this.title.setPageTitle('Rooms');
    }
}