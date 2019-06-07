import { Component } from '@angular/core';
import { MoneyServiceProxy } from 'src/shared/service-proxy/service-proxies';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'money-tracker';
  budgetName: string;
  constructor(private _moneyService: MoneyServiceProxy) {
    this.getBudgetName();
  }

  getBudgetName() {
    this._moneyService.getBudget().subscribe(name => {
      this.budgetName = name;
    });
  }
}
