import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})

export class HomeComponent {
  public loading: boolean=false;
  public peopleList: People[];
  public searchName: string;
  private baseUrl: string;
  private http: HttpClient;
  public imageWidth: number = 50;
  public imageMargin: number = 2;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
    this.http = http;
    this.GetPeople();
  }

  public GetPeople() {
    this.loading = true;
    this.http.get<People[]>(this.baseUrl + 'People/Get').subscribe(result => {
      this.peopleList = result;
      this.loading = false;
    }, error => console.error(error));
  }

  public SearchByName() {
    if (this.searchName === '' || this.searchName === undefined) {
      this.GetPeople();
      return;
    }
    this.loading = true;
    this.http.get<People[]>(this.baseUrl + 'People/People/' + this.searchName).subscribe(result => {
      this.peopleList = result;
      this.loading = false;
    }, error => console.error(error));
  }
}

interface People {
  firstName: string;
  lastName: string;
  age: number;
  address: string;
  interest: string;
  imageUrl: string;
}
