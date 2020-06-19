import { NgModule } from '@angular/core';
import { ShoppingCartComponent } from './shopping-cart/shopping-cart.component';
import { ShoppingCartItemsComponent } from './shopping-cart/shopping-cart-items/shopping-cart-items.component';
import { OrderSummaryComponent } from './order-summary/order-summary.component';
import { CheckoutAddressComponent } from './checkout/checkout-address/checkout-address.component';
import { CheckoutDeliveryMethodComponent } from './checkout/checkout-delivery-method/checkout-delivery-method.component';
import { CheckoutPaymentMethodComponent } from './checkout/checkout-payment-method/checkout-payment-method.component';
import { CheckoutOrderReviewComponent } from './checkout/checkout-order-review/checkout-order-review.component';
import { CheckoutComponent } from './checkout/checkout.component';
import { CouponComponent } from './shopping-cart/coupon/coupon.component';
import { OrderRoutingModule } from './order-routing.module';
import { SharedModule } from '../shared/shared.module';

@NgModule({
    declarations:[
        ShoppingCartComponent,
        ShoppingCartItemsComponent,
        OrderSummaryComponent,
        CheckoutAddressComponent,
        CheckoutDeliveryMethodComponent,
        CheckoutPaymentMethodComponent,
        CheckoutOrderReviewComponent,
        CheckoutComponent,
        CouponComponent,
    ],
    imports:[
        OrderRoutingModule,
        SharedModule
    ]
})
export class OrderModule{}