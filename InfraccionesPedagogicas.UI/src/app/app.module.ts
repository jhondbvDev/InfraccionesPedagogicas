import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PublicMasterComponent } from './layout/public/master/master.component';
import { SecureMasterComponent } from './layout/secure/master/master.component';
import { LoginInfractorComponent } from './public/login-infractor/login-infractor.component';
import { LoginFuncionarioComponent } from './public/login-funcionario/login-funcionario.component';
import { DashboardComponent } from './secure/dashboard/dashboard.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatToolbarModule, MatIconModule, MatTooltipModule, MatCardModule, MatButtonModule, MatInputModule } from '@angular/material';

@NgModule({
  declarations: [
    AppComponent,
    PublicMasterComponent,
    SecureMasterComponent,
    LoginInfractorComponent,
    LoginFuncionarioComponent,
    DashboardComponent
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
    MatInputModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
