import { Component, OnInit } from '@angular/core';

export interface Sala {
  infNumber: string;
  date: string;
  link: string;
  slots: number;
  teacher: string;
}

const DATA: Sala[] = [
  { infNumber: '12234355', date: '22/5/2022', link: 'Link', slots: 30, teacher: 'Mauricio Mercado'},
  { infNumber: '52667355', date: '22/5/2022', link: 'Link', slots: 25, teacher: 'Orlando Mejia'}
];

@Component({
  selector: 'app-dashboard-sm',
  templateUrl: './dashboard-sm.component.html',
  styleUrls: ['./dashboard-sm.component.scss']
})
export class DashboardSmComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

  displayedColumns: string[] = ['infNumber', 'date', 'link', 'slots', 'teacher', 'detailsAction', 'editAction'];
  dataSource = DATA;
}
