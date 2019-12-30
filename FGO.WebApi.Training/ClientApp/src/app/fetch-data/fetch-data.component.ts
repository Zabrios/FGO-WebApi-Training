import { Component, Inject, NgModule, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { RouterModule} from '@angular/router';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})

@NgModule({
    imports: [RouterModule],
})
export class FetchDataComponent implements OnInit{
  public servants: ServantBaseModel[];
  public apiUrl = 'api/Servant';
  baseUrl: string;
  http: HttpClient;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
    this.http = http;
    let headers = new HttpHeaders({ 'Content-Type': 'application-json'});
  }

  ngOnInit() {
    this.http.get<ServantBaseModel[]>(this.baseUrl + this.apiUrl).subscribe(result => {
      this.servants = result;
      console.log(result);
    }, error => console.error(error));

  }
}

interface ServantBaseModel {
  id: number;
  name: string;
  cost: number;
  servantClass: string;
  maxLvl: number;
  rarityNum: number;
  rarityName: string;
  atkLv1: number;
  atkMaxLv: number;
  atkLvl100: number;
  hpLv1: number;
  hpMaxLv: number;
  hpLvl100: number;
  commandCards: string;
  aliases: string;
  ascensions: string;
}
