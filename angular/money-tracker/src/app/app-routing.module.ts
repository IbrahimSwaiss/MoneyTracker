import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { BudgetComponent } from './budget/budget.component';

const routes: Routes = [
  { path: "", redirectTo: "/budget", pathMatch: "full" },
  { path: "budget", component: BudgetComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
