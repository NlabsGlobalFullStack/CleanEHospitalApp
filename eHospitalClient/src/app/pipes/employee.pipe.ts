import { Pipe, PipeTransform } from '@angular/core';
import { UserModel } from '../models/user.model';

@Pipe({
  name: 'employee',
  standalone: true
})
export class EmployeePipe implements PipeTransform {

  transform(value: UserModel, ...args: UserModel[]): unknown {
    return null;
  }

}
