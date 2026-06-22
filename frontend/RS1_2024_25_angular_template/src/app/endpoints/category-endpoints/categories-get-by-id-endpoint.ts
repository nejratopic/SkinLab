import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {MyConfig} from '../../my-config';
import {MyBaseEndpointAsync} from '../../helper/my-base-endpoint-async.interface';

export interface CategoriesGetByIdResponse {
    id: number;
    name: string;
    description: string;
    createdAt: Date; 
    updatedAt: Date; 
}

@Injectable({
  providedIn: 'root'
})
export class CategoryGetByIdEndpointService implements MyBaseEndpointAsync<number, CategoriesGetByIdResponse> {
  private apiUrl = `${MyConfig.api_address}/categories`;

  constructor(private httpClient: HttpClient) {
  }

  handleAsync(id: number) {
    return this.httpClient.get<CategoriesGetByIdResponse>(`${this.apiUrl}/${id}`);
  }
}
