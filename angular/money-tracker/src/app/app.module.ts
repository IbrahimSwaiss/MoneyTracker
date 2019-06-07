import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MoneyServiceProxy, API_BASE_URL } from 'src/shared/service-proxy/service-proxies';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule
  ],
  providers: [
    {
      provide: API_BASE_URL,
      useValue: environment.apiRoot
    },
    HttpClient,
    MoneyServiceProxy],
  bootstrap: [AppComponent]
})
export class AppModule { }
