import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {MyConfig} from '../../my-config';
import {MyBaseEndpointAsync} from '../../helper/my-base-endpoint-async.interface';

export interface BrandsGetByIdResponse {
  id: number;
  name: string;
  description: string;
  createdAt: Date;
  updatedAt: Date;
}

@Injectable({
  providedIn: 'root'
})
export class BrandGetByIdEndpointService implements MyBaseEndpointAsync<number, BrandsGetByIdResponse> {
  private apiUrl = `${MyConfig.api_address}/brands`;

  constructor(private httpClient: HttpClient) {
  }

  handleAsync(id: number) {
    return this.httpClient.get<BrandsGetByIdResponse>(`${this.apiUrl}/${id}`);
  }
}

