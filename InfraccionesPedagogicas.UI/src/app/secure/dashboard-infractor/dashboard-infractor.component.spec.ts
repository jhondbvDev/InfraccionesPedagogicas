import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DashboardInfractorComponent } from './dashboard-infractor.component';

describe('DashboardInfractorComponent', () => {
  let component: DashboardInfractorComponent;
  let fixture: ComponentFixture<DashboardInfractorComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DashboardInfractorComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DashboardInfractorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
