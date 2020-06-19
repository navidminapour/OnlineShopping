import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CheckoutComponent } from './checkout/checkout.component';
import { CheckoutAddressComponent } from './checkout/checkout-address/checkout-address.component';
import { CheckoutDeliveryMethodComponent } from './checkout/checkout-delivery-method/checkout-delivery-method.component';
import { CheckoutPaymentMethodComponent } from './checkout/checkout-payment-method/checkout-payment-method.component';
import { CheckoutOrderReviewComponent } from './checkout/checkout-order-review/checkout-order-review.component';
import { ShoppingCartComponent } from './shopping-cart/shopping-cart.component';


const routes: Routes = [
    { path: 'shopping-cart', component: ShoppingCartComponent },
    {
        path: 'checkout', component: CheckoutComponent, children: [
            { path: '', component: CheckoutAddressComponent },
            { path: 'address', component: CheckoutAddressComponent },
            { path: 'delivery-method', component: CheckoutDeliveryMethodComponent },
            { path: 'payment-method', component: CheckoutPaymentMethodComponent },
            { path: 'order-review', component: CheckoutOrderReviewComponent }
        ]
    }];
@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class OrderRoutingModule { }