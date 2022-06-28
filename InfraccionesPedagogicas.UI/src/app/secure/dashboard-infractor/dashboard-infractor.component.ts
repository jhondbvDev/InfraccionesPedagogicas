import { Component, OnInit } from '@angular/core';

export interface Infracciones {
  date: string;
  concept: string;
}

const DATA: Infracciones[] = [
  { date: '23/9/2022', concept: 'Infraccion Pedagogica' },
  { date: '27/9/2022', concept: 'Infraccion Pedagogica'}
];

@Component({
  selector: 'app-dashboard-infractor',
  templateUrl: './dashboard-infractor.component.html',
  styleUrls: ['./dashboard-infractor.component.scss']
})
export class DashboardInfractorComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

  displayedColumns: string[] = ['date', 'concept'];
  dataSource = DATA;

}
