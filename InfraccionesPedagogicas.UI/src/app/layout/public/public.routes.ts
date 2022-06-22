import { LoginInfractorComponent } from './../../public/login-infractor/login-infractor.component';
import { LoginFuncionarioComponent } from '../../public/login-funcionario/login-funcionario.component';
import { Routes, RouterModule } from '@angular/router';


export const PUBLIC_ROUTES: Routes = [
  { path: '', redirectTo: 'infractor/login', pathMatch: 'full' },
  { path: 'infractor/login', component: LoginInfractorComponent },
  { path: 'funcionario/login', component: LoginFuncionarioComponent }
];
