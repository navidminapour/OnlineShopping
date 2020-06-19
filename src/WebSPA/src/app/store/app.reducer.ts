import * as fromOrder from "../order/store/order.reducer";
import { ActionReducerMap } from '@ngrx/store';

export interface AppState{
    order: fromOrder.State
}

export const appReducer : ActionReducerMap<AppState> = {
    order : fromOrder.orderReducer
};