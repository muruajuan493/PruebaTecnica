import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CanActivateViaAuthGuard } from './Authorization/Guards/can-activate-via-auth.guard';
import { LoginFormComponent } from './Authorization/LoginForm.component';
import { MainComponent } from './main/main.component';

const appRoutes: Routes = [
  { path: 'Inicio', component: MainComponent, canActivate: [CanActivateViaAuthGuard] },
  { path: 'Login', component: LoginFormComponent },
  { path: '**', redirectTo: 'Inicio', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(appRoutes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
