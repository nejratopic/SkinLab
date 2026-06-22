import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {MyConfig} from '../../my-config';
import {MyBaseEndpointAsync} from '../../helper/my-base-endpoint-async.interface';

export interface SubcategoriesGetByIdResponse {
    id: number;
    name: string;
    description: string;
    categoryId: number;
    createdAt: Date; 
    updatedAt: Date; 
}

@Injectable({
  providedIn: 'root'
})
export class SubcategoryGetByIdEndpointService implements MyBaseEndpointAsync<number, SubcategoriesGetByIdResponse> {
  private apiUrl = `${MyConfig.api_address}/subcategories`;

  constructor(private httpClient: HttpClient) {
  }

  handleAsync(id: number) {
    return this.httpClient.get<SubcategoriesGetByIdResponse>(`${this.apiUrl}/${id}`);
  }
}
