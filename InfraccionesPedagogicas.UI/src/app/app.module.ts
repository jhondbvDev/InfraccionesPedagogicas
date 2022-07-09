import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PublicMasterComponent } from './layout/public/master/master.component';
import { SecureMasterComponent } from './layout/secure/master/master.component';
import { LoginInfractorComponent } from './public/login-infractor/login-infractor.component';
import { LoginFuncionarioComponent } from './public/login-funcionario/login-funcionario.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { DashboardInfractorComponent } from './private/dashboard-infractor/dashboard-infractor.component';
import { DatosInfractorComponent } from './private/datos-infractor/datos-infractor.component';
import { ScheduleConfirmationDialogComponent } from './common/dialogs/schedule-confirmation-dialog/schedule-confirmation-dialog.component';
import { DashboardTmbComponent } from './private/dashboard-tmb/dashboard-tmb.component';
import { DashboardSmComponent } from './private/dashboard-sm/dashboard-sm.component';
import { AttendanceCheckingDialogComponent } from './common/dialogs/attendance-checking-dialog/attendance-checking-dialog.component';
import { RoomCreationDialogComponent } from './common/dialogs/room-creation-dialog/room-creation-dialog.component';
import { MeetingCalendarComponent } from './user-control/meeting-calendar/meeting-calendar.component';
import { UserCreationDialogComponent } from './common/dialogs/user-creation-dialog/user-creation-dialog.component';
import { MaterialModule } from './material.module';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

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
    HttpClientModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule
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
