import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from './common/guards/auth.guard';
import { PublicMasterComponent } from './layout/public/master/master.component';
import { PUBLIC_ROUTES } from './layout/public/public.routes';
import { SecureMasterComponent } from './layout/secure/master/master.component';
import { SECURE_ROUTES } from './layout/secure/secure.routes';

const routes: Routes = [
  { path: '', redirectTo: 'infractor/login', pathMatch: 'full' },
  { path: '', component: PublicMasterComponent, data: { title: 'Login' }, children: PUBLIC_ROUTES },
  { path: '', component: SecureMasterComponent, data: { title: 'Dashboard' }, children: SECURE_ROUTES },
  { path: '**', redirectTo: 'infractor/login' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { relativeLinkResolution: 'legacy' })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
