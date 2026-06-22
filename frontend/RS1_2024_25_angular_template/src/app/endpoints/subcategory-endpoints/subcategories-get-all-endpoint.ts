import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {MyConfig} from '../../my-config';
import {MyBaseEndpointAsync} from '../../helper/my-base-endpoint-async.interface';

export interface SubcategoryGetAllResponse {
    id: number;
    name: string;
    description: string;
    categoryName: string,
    createdAt: string; 
    updatedAt: string; 
  }
  
@Injectable({
  providedIn: 'root'
})
export class SubcategoryGetAllService implements MyBaseEndpointAsync<void, SubcategoryGetAllResponse[]> {
  private apiUrl = `${MyConfig.api_address}/subcategories/all`;

  constructor(private httpClient: HttpClient) {
  }



  handleAsync() {
    return this.httpClient.get<SubcategoryGetAllResponse[]>(`${this.apiUrl}`);
  }
}
