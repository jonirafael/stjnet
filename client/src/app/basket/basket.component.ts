import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { BasketService } from './basket.service';
import { BasketItem } from '../shared/models/basket';

@Component({
  selector: 'app-basket',
  templateUrl: './basket.component.html',
  styleUrls: ['./basket.component.scss']
})

export class BasketComponent {
  @ViewChild('disc') searchTerm?: ElementRef;

  constructor(public basketService: BasketService) { }

  incrementQuantity(item: BasketItem) {
    this.basketService.addItemToBasket(item,1,item.disc);
  }

  removeItem(id: number, qty: number) {
    this.basketService.removeItemFromBasket(id, qty);
  }

  setDisc(item: BasketItem) {
    this.basketService.addItemToBasket(item,0,this.searchTerm?.nativeElement.value)
  }
}

