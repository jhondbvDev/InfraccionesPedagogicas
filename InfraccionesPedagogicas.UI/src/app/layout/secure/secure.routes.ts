import { DashboardComponent } from './../../secure/dashboard/dashboard.component';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from './../../common/auth.guard';

export const SECURE_ROUTES: Routes = [
  { path: 'dashboard', component: DashboardComponent, canActivate: [AuthGuard] },
];
