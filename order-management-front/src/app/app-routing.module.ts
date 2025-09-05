import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './order-management/component/login.component';
import { OrderComponent } from './order-management/component/order.component';
import { OrderManagementComponent } from './order-management/component/order-management.component';

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: '', redirectTo: 'login', pathMatch: 'full' },
  { path: 'sales', component: OrderManagementComponent },
  { path: 'orders', component: OrderComponent },
  { path: '**', redirectTo: 'login' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
