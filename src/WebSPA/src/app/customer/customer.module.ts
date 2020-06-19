import { NgModule } from '@angular/core';
import { CustomerComponent } from './customer.component';
import { CustomerOrdersComponent } from './customer-orders/customer-orders.component';
import { CustomerWishlistComponent } from './customer-wishlist/customer-wishlist.component';
import { CustomerOrderComponent } from './customer-order/customer-order.component';
import { CustomerAccountComponent } from './customer-account/customer-account.component';
import { SharedModule } from '../shared/shared.module';
import { CustomerRoutingModule } from './customer-routing.module';

@NgModule({
    declarations: [
        CustomerComponent,
        CustomerOrdersComponent,
        CustomerWishlistComponent,
        CustomerOrderComponent,
        CustomerAccountComponent
    ],
    imports: [
        CustomerRoutingModule,
        SharedModule
    ]
})
export class CustomerModule { }