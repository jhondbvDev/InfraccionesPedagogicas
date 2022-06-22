import { DatosInfractorComponent } from '../../secure/datos-infractor/datos-infractor.component';
import { DashboardInfractorComponent } from './../../secure/dashboard-infractor/dashboard-infractor.component';
import { DashboardFuncionarioComponent } from './../../secure/dashboard-funcionario/dashboard-funcionario.component';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from './../../common/guards/auth.guard';

export const SECURE_ROUTES: Routes = [
  { path: 'infractor/actualizacionDeDatos', component: DatosInfractorComponent },
  { path: 'infractor/dashboard', component: DashboardInfractorComponent },
  { path: 'funcionario/dashboard', component: DashboardFuncionarioComponent},
];
