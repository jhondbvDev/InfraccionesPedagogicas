import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-meeting-calendar',
  templateUrl: './meeting-calendar.component.html',
  styleUrls: ['./meeting-calendar.component.scss']
})
export class MeetingCalendarComponent implements OnInit {

  selected: Date | null;
  minDate: Date;
  listDates = Array<Date>();
  currentListDate = Array<Date>();
  constructor() {
    this.selected = new Date();
    this.minDate = new Date();
    this.listDates.push(new Date(2022, 6, 14, 11, 20));
    this.listDates.push(new Date(2022, 6, 12, 12, 0));
    this.listDates.push(new Date(2022, 6, 13, 13, 0));
    this.listDates.push(new Date(2022, 6, 14, 14, 30));
    this.listDates.push(new Date(2022, 6, 13, 15, 45));
    this.listDates.push(new Date(2022, 6, 14, 9, 20));
  }

  ngOnInit(): void {
  }

  dateChange(dateChanged: Date | null): void {
    this.currentListDate = Array<Date>();
    this.currentListDate = this.listDates.filter((obj) => obj.getDate() === dateChanged.getDate());
  }

  availableDates = (d: Date): boolean => {
    return this.listDates.some(x => x.toISOString().slice(0, 10) === d.toISOString().slice(0, 10));
  }

}
