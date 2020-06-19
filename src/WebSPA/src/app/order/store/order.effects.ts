import { Injectable } from "@angular/core";
import { Effect, Actions, ofType } from "@ngrx/effects";
import * as OrderActions from "./order.actions";
import { switchMap, withLatestFrom } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';
import { Store } from '@ngrx/store';
import * as fromApp from '../../store/app.reducer';

@Injectable()
export class OrderEffects{
    @Effect({dispatch: false})
    createOrder = this.actions$.pipe(
        ofType(OrderActions.CREATE_ORDER),
        withLatestFrom(this.store.select('order')),
        switchMap(([actionData, orderState]) => {
            return this.http.post(
                "https://localhost:32001/Orders",
                orderState.order
            );
        })
    );

    constructor(
        private actions$: Actions, 
        private http: HttpClient, 
        private store: Store<fromApp.AppState>) {}
}