import { Order, OrderItem } from "src/app/shared/order.model";
import * as OrderActions from "./order.actions";

export interface State {
    order : Order;
}

const initialState: State = {
    order: new Order(1, 
        [
            new OrderItem(1,4), 
            new OrderItem(2,3)
        ])
}

export function orderReducer(
    state = initialState, 
    action: OrderActions.OrderActions)
    {
        switch(action.type){
            case OrderActions.CREATE_ORDER:
                return state;
            default:
                return state;
        }
    }