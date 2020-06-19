import { Action } from '@ngrx/store';

export const CREATE_ORDER = "[Order] Create Order";

export class CreateOrder implements Action{
    readonly type = CREATE_ORDER;
}

export type OrderActions = CreateOrder;