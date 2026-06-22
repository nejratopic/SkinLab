import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {MyConfig} from '../../my-config';
import {MyBaseEndpointAsync} from '../../helper/my-base-endpoint-async.interface';

export interface ProductsGetByIdResponse {
  id: number;
  createdAt: string;
  updatedAt: string;
  name: string;
  description: string;
  price: number;
  stockQuantity: number;
  packSize: string;
  ingredients: string;
  howToUse: string;
  subcategoryId: number;
  brandId: number;
  productTypeId: number;
  skinTypeId: number;
  categoryId: number;
}

@Injectable({
  providedIn: 'root'
})
export class ProductGetByIdEndpointService implements MyBaseEndpointAsync<number, ProductsGetByIdResponse> {
  private apiUrl = `${MyConfig.api_address}/products`;

  constructor(private httpClient: HttpClient) {
  }

  handleAsync(id: number) {
    return this.httpClient.get<ProductsGetByIdResponse>(`${this.apiUrl}/${id}`);
  }
}
