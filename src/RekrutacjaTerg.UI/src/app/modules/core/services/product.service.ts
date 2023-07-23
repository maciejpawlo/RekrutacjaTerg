import { Injectable } from '@angular/core';
import { ConfigurationService } from './configuration.service';
import { Observable } from 'rxjs';
import { HttpClient, HttpParams } from '@angular/common/http';
import { CreateProductCommand } from '../models/requests/create-product-command';
import { GetProductsQuery } from '../models/requests/get-products-query';
import { PagedList } from '../models/responses/paged-list';
import { Product } from '../models/product';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  apiUrl!: string;

  constructor(
    private configurationService: ConfigurationService,
    private http: HttpClient
    ) {
    this.apiUrl = this.configurationService.configuration.apiUrl + '/product';
  }

  add(request: CreateProductCommand): Observable<string>{
    return this.http.post<string>(this.apiUrl, request);
  }

  get(request: GetProductsQuery): Observable<PagedList<Product>>{
    const options = request ?
    {
      params: new HttpParams()
        .set('PageSettings.PageSize', request.pageSettings.pageSize)
        .set('PageSettings.PageNumber', request.pageSettings.pageNumber)
        .set('Name', request.name ?? "")
        .set('Code', request.code ?? "")
        .set('MaxPrice', request.maxPrice ?? "")
        .set('MinPrice', request.minPrice ?? "")
    }
    : {};
    return this.http.get<PagedList<Product>>(this.apiUrl, options);
  }
}
