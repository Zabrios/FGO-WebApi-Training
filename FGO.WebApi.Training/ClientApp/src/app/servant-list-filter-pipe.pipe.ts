import { Pipe, PipeTransform, Injectable } from '@angular/core';

@Pipe({
  name: 'servantListFilterPipe'
})
@Injectable()
export class ServantListFilterPipePipe implements PipeTransform {

  transform(items: any[], name: string, value: string): any[] {
    if (!items) { return []; }
    if (!name || !value) {
      return items;
    }
    return items.filter(singleItem => singleItem[name].toLowerCase().includes(value.toLowerCase()));
  }

}
