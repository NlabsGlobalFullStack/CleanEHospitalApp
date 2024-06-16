import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'nurse',
  standalone: true
})
export class NursePipe implements PipeTransform {

  transform(value: unknown, ...args: unknown[]): unknown {
    return null;
  }

}
