import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PublicMasterComponent } from './layout/public/master/master.component';
import { SecureMasterComponent } from './layout/secure/master/master.component';
import { LoginInfractorComponent } from './public/login-infractor/login-infractor.component';
import { LoginFuncionarioComponent } from './public/login-funcionario/login-funcionario.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatToolbarModule, MatIconModule, MatTooltipModule, MatCardModule, MatButtonModule, MatInputModule, MatTableModule, MatDialogModule } from '@angular/material';
import { DashboardInfractorComponent } from './secure/dashboard-infractor/dashboard-infractor.component';
import { DashboardFuncionarioComponent } from './secure/dashboard-funcionario/dashboard-funcionario.component';
import { DatosInfractorComponent } from './secure/datos-infractor/datos-infractor.component';
import { ScheduleConfirmationDialogComponent } from './common/dialogs/schedule-confirmation-dialog/schedule-confirmation-dialog.component';

@NgModule({
  declarations: [
    AppComponent,
    PublicMasterComponent,
    SecureMasterComponent,
    LoginInfractorComponent,
    LoginFuncionarioComponent,
    DashboardInfractorComponent,
    DashboardFuncionarioComponent,
    DatosInfractorComponent,
    ScheduleConfirmationDialogComponent,
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
    MatDialogModule
  ],
  entryComponents: [ScheduleConfirmationDialogComponent],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
