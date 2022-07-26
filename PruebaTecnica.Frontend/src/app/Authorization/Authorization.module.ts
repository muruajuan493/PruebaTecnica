import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import { SharedModule } from '../Core/Shared.module';
import { AuthorizationInterceptor } from './Interceptors/authorization.interceptor';
import { LoginFormComponent } from './LoginForm.component';
import { AuthorizationService } from './Services/Authorization.service';

@NgModule({
  imports: [SharedModule],
  declarations: [LoginFormComponent],
  providers: [
    AuthorizationService,
    CookieService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthorizationInterceptor,
      multi: true,
    },
  ],
})
export class AuthorizationModule {}
