import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";

import { AppRoutingModule } from "./app-routing.module";
import { AppComponent } from "./app.component";
import {
  MoneyServiceProxy,
  API_BASE_URL
} from "src/shared/service-proxy/service-proxies";
import { HttpClient } from "@angular/common/http";
import { environment } from "src/environments/environment";
import { CoreModule } from "./core/core.module";
import { AppMaterialModule } from "./app-material/app-material.module";
import { BudgetComponent } from './budget/budget.component';

@NgModule({
  declarations: [AppComponent, BudgetComponent],
  imports: [BrowserModule, CoreModule, AppRoutingModule, AppMaterialModule],
  providers: [
    {
      provide: API_BASE_URL,
      useValue: environment.apiRoot
    },
    HttpClient,
    MoneyServiceProxy
  ],
  bootstrap: [AppComponent]
})
export class AppModule {}
