import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'round'
})
export class BasketPipe implements PipeTransform {

  transform(input: number) {
    return Math.floor(input);
  }

}
