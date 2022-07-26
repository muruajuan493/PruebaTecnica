import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { AppRoutingModule } from './app.routing.module';
import { CommonService } from './Common/Services/Common.service';
import { HttpClient } from './Common/Services/HttpClient.Service';
import { CoreModule } from './Core/Core.module';
import { MainModule } from './main/main.module';

@NgModule({
  declarations: [AppComponent],
  imports: [CoreModule, AppRoutingModule, MainModule],
  providers: [HttpClient, CommonService],
  bootstrap: [AppComponent],
})
export class AppModule {}
