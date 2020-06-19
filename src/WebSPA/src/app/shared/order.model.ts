export class Order{
    constructor(public customerId: number, public items : OrderItem[]){}
}

export class OrderItem{
    constructor(public productId: number, public quantity: number){}
}