import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PublicMasterComponent } from './layout/public/master/master.component';
import { SecureMasterComponent } from './layout/secure/master/master.component';
import { LoginInfractorComponent } from './public/login-infractor/login-infractor.component';
import { LoginFuncionarioComponent } from './public/login-funcionario/login-funcionario.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {
  MatToolbarModule,
  MatIconModule,
  MatTooltipModule,
  MatCardModule,
  MatButtonModule,
  MatInputModule,
  MatTableModule,
  MatDialogModule,
  MatCheckboxModule,
  MatTabsModule
} from '@angular/material';
import { DashboardInfractorComponent } from './secure/dashboard-infractor/dashboard-infractor.component';
import { DatosInfractorComponent } from './secure/datos-infractor/datos-infractor.component';
import { ScheduleConfirmationDialogComponent } from './common/dialogs/schedule-confirmation-dialog/schedule-confirmation-dialog.component';
import { DashboardTmbComponent } from './secure/dashboard-tmb/dashboard-tmb.component';
import { DashboardSmComponent } from './secure/dashboard-sm/dashboard-sm.component';
import { AttendanceCheckingDialogComponent } from './common/dialogs/attendance-checking-dialog/attendance-checking-dialog.component';
import { RoomCreationDialogComponent } from './common/dialogs/room-creation-dialog/room-creation-dialog.component';
import { MeetingCalendarComponent } from './user-control/meeting-calendar/meeting-calendar.component';
import { UserCreationDialogComponent } from './common/dialogs/user-creation-dialog/user-creation-dialog.component';

@NgModule({
  declarations: [
    AppComponent,
    PublicMasterComponent,
    SecureMasterComponent,
    LoginInfractorComponent,
    LoginFuncionarioComponent,
    DashboardInfractorComponent,
    DatosInfractorComponent,
    ScheduleConfirmationDialogComponent,
    DashboardTmbComponent,
    DashboardSmComponent,
    AttendanceCheckingDialogComponent,
    RoomCreationDialogComponent,
    UserCreationDialogComponent,
    MeetingCalendarComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatToolbarModule,
    MatIconModule,
    MatTooltipModule,
    MatCardModule,
    MatButtonModule,
    MatInputModule,
    MatTableModule,
    MatDialogModule,
    MatCheckboxModule,
    MatTabsModule
  ],
  entryComponents: [
    ScheduleConfirmationDialogComponent,
    AttendanceCheckingDialogComponent,
    RoomCreationDialogComponent,
    UserCreationDialogComponent
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
