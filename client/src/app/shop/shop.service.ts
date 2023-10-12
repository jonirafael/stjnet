import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Pagination } from '../shared/models/pagination';
import { Product } from '../shared/models/product';
import { Factory } from '../shared/models/factory';
import { Category } from '../shared/models/category';
import { ShopParams } from '../shared/models/shopParams';

@Injectable({
  providedIn: 'root'
})
export class ShopService {

  baseUrl = 'https://localhost:5001/api/';
  constructor(private http: HttpClient) { }

  getProducts(shopParams: ShopParams) {
    let params = new HttpParams();

    if (shopParams.factoryId > 0) params = params.append('factoryId', shopParams.factoryId);
    if (shopParams.categoryId > 0) params = params.append('categoryId', shopParams.categoryId);
    params = params.append('sort', shopParams.sort);
    params = params.append('pageIndex', shopParams.pageNumber);
    params = params.append('pageSize', shopParams.pageSize);
    if (shopParams.search) params = params.append('search', shopParams.search);

    return this.http.get<Pagination<Product[]>>(this.baseUrl + 'products', { params })
  }

  getFactories() {
    return this.http.get<Factory[]>(this.baseUrl + 'products/factories');
  }

  getCategories() {
    return this.http.get<Category[]>(this.baseUrl + 'products/categories');
  }
}
