import { Injectable } from '@angular/core';
import {
  CanActivate,
  Router
} from '@angular/router';
import { AuthorizationService } from '../Services/Authorization.service';

@Injectable({
  providedIn: 'root',
})
export class CanActivateViaAuthGuard implements CanActivate {
  constructor(private authService: AuthorizationService, private router: Router) {}

  canActivate() {
    if (!this.authService.isLogged()) {
      this.router.navigate(['/Login']);
      return false;
    }

    return true;
  }
}
