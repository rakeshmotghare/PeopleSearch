import { Component } from '@angular/core';
import { HomeService } from './home.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})

export class HomeComponent {
  public loading: boolean = false;
  peopleList: any = [];
  searchName: string;
  imageWidth: number = 50;
  imageMargin: number = 2;

  constructor(private homeService: HomeService) {
    this.GetPeople();
  }

  public GetPeople() {
    this.loading = true;
    return this.homeService.getPeople().subscribe((data: {}) => {
      this.peopleList = data;
      this.loading = false;
    });
  }

  public SearchByName() {
    if (this.searchName === '' || this.searchName === undefined) {
      this.GetPeople();
      return;
    }

    this.loading = true;
    return this.homeService.searchByName(this.searchName).subscribe((data: {}) => {
      this.peopleList = data;
      this.loading = false;
    });
  }
}

