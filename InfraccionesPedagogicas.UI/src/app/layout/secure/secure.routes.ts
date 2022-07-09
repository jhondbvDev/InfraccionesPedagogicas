import { DatosInfractorComponent } from '../../private/datos-infractor/datos-infractor.component';
import { DashboardInfractorComponent } from '../../private/dashboard-infractor/dashboard-infractor.component';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from './../../common/guards/auth.guard';
import { DashboardTmbComponent } from '../../private/dashboard-tmb/dashboard-tmb.component';
import { DashboardSmComponent } from '../../private/dashboard-sm/dashboard-sm.component';

export const SECURE_ROUTES: Routes = [
  { path: 'infractor/actualizacionDeDatos', component: DatosInfractorComponent },
  { path: 'infractor/dashboard', component: DashboardInfractorComponent },
  { path: 'tmb/dashboard', component: DashboardTmbComponent },
  { path: 'sm/dashboard', component: DashboardSmComponent },
];
