import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BasketComponent } from './basket.component';
import { BasketRoutingModule } from './basket-routing.module';
import { BasketPipe } from './basket.pipe';
import { SharedModule } from '../shared/shared.module';
import { RouterModule } from '@angular/router';



@NgModule({
  declarations: [
    BasketComponent,
    BasketPipe
  ],
  imports: [
    CommonModule,
    BasketRoutingModule,
    SharedModule
  ]
})
export class BasketModule { }
