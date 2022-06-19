import { LoginInfractorComponent } from './../../public/login-infractor/login-infractor.component';
import { Routes, RouterModule } from '@angular/router';


export const PUBLIC_ROUTES: Routes = [
  { path: '', redirectTo: 'infractor/login', pathMatch: 'full' },
  { path: 'infractor/login', component: LoginInfractorComponent }
];
