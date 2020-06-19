import { Component, OnInit } from '@angular/core';
import * as fromApp from "../../../store/app.reducer";
import { Store } from '@ngrx/store';
import * as OrderActions from "../../store/order.actions";
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-shopping-cart-items',
  templateUrl: './shopping-cart-items.component.html',
  styleUrls: ['./shopping-cart-items.component.css']
})
export class ShoppingCartItemsComponent implements OnInit {

  constructor(
    private store: Store<fromApp.AppState>, 
    private router: Router,
    private route: ActivatedRoute
  ) { }

  ngOnInit() {
  }

  onCreateOrder(){
    this.store.dispatch(new OrderActions.CreateOrder());
    this.router.navigate(["../checkout/address"], {relativeTo: this.route});
  }
}
