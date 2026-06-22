import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {MyConfig} from '../../my-config';
import {MyBaseEndpointAsync} from '../../helper/my-base-endpoint-async.interface';

export interface CategoryGetAllResponse {
    id: number;
    name: string;
    description: string;
    createdAt: string; 
    updatedAt: string; 
  }
  
@Injectable({
  providedIn: 'root'
})
export class CategoryGetAllService implements MyBaseEndpointAsync<void, CategoryGetAllResponse[]> {
  private apiUrl = `${MyConfig.api_address}/categories/all`;

  constructor(private httpClient: HttpClient) {
  }



  handleAsync() {
    return this.httpClient.get<CategoryGetAllResponse[]>(`${this.apiUrl}`);
  }
}
