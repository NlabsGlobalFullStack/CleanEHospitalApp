import { Component } from '@angular/core';
import { BreadcrumpComponent } from '../../layout/shared/breadcrump/breadcrump.component';
import { TableComponent } from '../../layout/shared/table/table.component';
import { TitleService } from '../../../services/title.service';
import { UserModel } from '../../../models/user.model';
import { DatePipe } from '@angular/common';
import { InputComponent } from '../../layout/shared/input/input.component';
import { SelectComponent } from '../../layout/shared/select/select.component';
import { TextareaComponent } from '../../layout/shared/textarea/textarea.component';
import { EmployeeModel } from '../../../models/employee.model';

@Component({
  selector: 'app-employee',
  standalone: true,
  imports: [BreadcrumpComponent, TableComponent, InputComponent, SelectComponent, TextareaComponent, DatePipe],
  templateUrl: './employee.component.html',
  styleUrl: './employee.component.css'
})
export class EmployeeComponent {
  employees: UserModel[] = [];
  departments = [] = [];
  employee: EmployeeModel = new EmployeeModel();
  constructor(private titleService: TitleService) { }

  ngOnInit(): void {
    this.titleService.setPrefix('eHospital ');
    this.titleService.setPageTitle('Employees');
  }

}
