import {Pipe, PipeTransform} from '@angular/core';
import {DatePipe} from '@angular/common';

@Pipe({
  name: 'yearDatePipe'
})
export class YearDatePipe extends
  DatePipe implements PipeTransform {
  transform(value: Date, args?: any): any {
    const date = new Date(value);
    return date.getFullYear();
  }
}
