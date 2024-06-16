import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'room',
  standalone: true
})
export class RoomPipe implements PipeTransform {

  transform(value: unknown, ...args: unknown[]): unknown {
    return null;
  }

}
