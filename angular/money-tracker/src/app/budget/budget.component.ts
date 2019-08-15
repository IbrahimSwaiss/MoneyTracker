import { Component, OnInit } from "@angular/core";
import {
  MoneyServiceProxy,
  TransactionInput,
  Budget
} from "src/shared/service-proxy/service-proxies";

@Component({
  selector: "budget-component",
  templateUrl: "./budget.component.html",
  styleUrls: ["./budget.component.scss"]
})
export class BudgetComponent implements OnInit {
  budget: Budget;
  constructor(private _moneyService: MoneyServiceProxy) {}

  ngOnInit() {
    this._moneyService.getBudget(1).subscribe(budget => {
      this.budget = budget;
    });
  }

  addBudget() {
    let transaction = new TransactionInput();
    transaction.name = "first transaction ever!";
    transaction.repeat = 0;
    transaction.amount = 10;
    let transactions: TransactionInput[] = [transaction];
    this._moneyService
      .addBudget("first budget ever!", 1000, 200, 50, undefined, transactions)
      .subscribe();
  }
}
