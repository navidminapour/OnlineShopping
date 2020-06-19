import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CustomerComponent } from './customer.component';
import { CustomerOrdersComponent } from './customer-orders/customer-orders.component';
import { CustomerOrderComponent } from './customer-order/customer-order.component';
import { CustomerWishlistComponent } from './customer-wishlist/customer-wishlist.component';
import { CustomerAccountComponent } from './customer-account/customer-account.component';

const routes: Routes = [{
    path: '', component: CustomerComponent, children: [
        { path: '', component: CustomerOrdersComponent },
        { path: 'orders', component: CustomerOrdersComponent },
        { path: 'orders/:id', component: CustomerOrderComponent },
        { path: 'wish-list', component: CustomerWishlistComponent },
        { path: 'account', component: CustomerAccountComponent }
    ]
}];
@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class CustomerRoutingModule{}