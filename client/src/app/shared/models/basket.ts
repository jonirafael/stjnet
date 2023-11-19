import * as cuid from "cuid"

export interface Basket {
    id: string
    items: BasketItem[]
  }
  
  export interface BasketItem {
    id: number
    productName: string
    hnappn: number
    quantity: number
    disc: number
    pictureURL: string
    category: string
    factory: string
  }

  export class Basket implements Basket {
    id = cuid();
    items: BasketItem[] = [];
  }

  export interface BasketTotals {
    shipping: number;
    subtotal: number;
    total: number;
  }