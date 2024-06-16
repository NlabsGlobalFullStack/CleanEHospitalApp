import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'patient',
  standalone: true
})
export class PatientPipe implements PipeTransform {

  transform(value: unknown, ...args: unknown[]): unknown {
    return null;
  }

}
