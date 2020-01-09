import { Component, Inject, NgModule, OnInit, ViewChild } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { RouterModule } from '@angular/router';
//import { FilterBoxComponent } from '../filter-box/filter-box.component';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html',
  styleUrls: ['./fetch-data.component.css']
})

@NgModule({
  imports: [RouterModule],
  //declarations: [FilterBoxComponent]
})

export class FetchDataComponent implements OnInit{
  //@ViewChild(FilterBoxComponent, { static: false }) filterBox;
  public servants: ServantBaseModel[];
  public apiUrl = 'api/Servant';
  public ascArt: any;
  public ascensionSrc: any;
  public displayArt: boolean;
  public ascensionName: string;
  public ascensions: string[];
  public searchString: string;
  selectedRow: number;
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

  //receiveMessage($event) {
  //  this.searchString = $event;
  //}

  onGetAscensionArt(id: number, name: string) {
    this.selectedRow = id;
    this.ascensionName = name;
    this.ascensions = [];
    this.http.get<string[]>(this.baseUrl + this.apiUrl + '/ascension/' + id).subscribe(result => {
      if (result !== null) {
        var ascensionsAux = result;
        for (let art of ascensionsAux) {
          this.ascensions.push('data:image/jpg;base64,' + art);
        }
        this.displayArt = true;
      }
      else {
        this.ascArt = null;
        this.ascensionSrc = null;
        this.displayArt = false;
      }
    });
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

