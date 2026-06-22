import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {MyConfig} from '../../my-config';
import {MyBaseEndpointAsync} from '../../helper/my-base-endpoint-async.interface';

export interface ProductUpdateOrInsertRequest {
  id?: number;
  name: string;
  description: string;
}

export interface ProductUpdateOrInsertResponse {
  id: number;
  name: string;
  description: string;
  createdAt: Date;
  updatedAt: Date;
}

@Injectable({
  providedIn: 'root'
})


export class ProductUpdateOrInsertEndpointService implements MyBaseEndpointAsync<ProductUpdateOrInsertRequest, ProductUpdateOrInsertResponse> {
  private apiUrl = `${MyConfig.api_address}/products`;

  constructor(private httpClient: HttpClient) {
  }

  handleAsync(request: ProductUpdateOrInsertRequest) {
    return this.httpClient.post<ProductUpdateOrInsertResponse>(`${this.apiUrl}`, request);
  }
}
