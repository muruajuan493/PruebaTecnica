import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AuthorizationModule } from '../Authorization/Authorization.module';

@NgModule({
  imports: [BrowserModule, HttpClientModule, AuthorizationModule],
  exports: [BrowserModule, HttpClientModule, AuthorizationModule],
})
export class CoreModule {}
