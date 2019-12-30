import { Component, Inject, NgModule } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { RouterModule} from '@angular/router';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})

@NgModule({
    imports: [RouterModule],
})
export class FetchDataComponent {
  public servants: ServantBaseModel[];
  public API = 'http://localhost:44380/api/';

  constructor(http: HttpClient) {
    http.get<ServantBaseModel[]>(this.API + 'Servant').subscribe(result => {
      this.servants = result;
    }, error => console.error(error));
  }
}

class ServantBaseModel {
  id: number;
  name: string;
  cost: number;
  class: string;
  maxlvl: number;
  rarityNumber: number;
  rarityName: string;
  atkLv1: number;
  atkMaxLvl: number;
  atkLvl100: number;
  hpLv1: number;
  hpMaxLvl: number;
  hpLvl100: number;
  commandCards: string; 
}
