import { DashboardInfractorComponent } from './../../secure/dashboard-infractor/dashboard-infractor.component';
import { DashboardFuncionarioComponent } from './../../secure/dashboard-funcionario/dashboard-funcionario.component';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from './../../common/auth.guard';

export const SECURE_ROUTES: Routes = [
  { path: 'infractor/dashboard', component: DashboardInfractorComponent, canActivate: [AuthGuard] },
  { path: 'funcionario/dashboard', component: DashboardFuncionarioComponent, canActivate: [AuthGuard]},
];
