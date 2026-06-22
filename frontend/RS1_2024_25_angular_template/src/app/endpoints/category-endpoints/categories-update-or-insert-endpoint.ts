import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {MyConfig} from '../../my-config';
import {MyBaseEndpointAsync} from '../../helper/my-base-endpoint-async.interface';

export interface CategoryUpdateOrInsertRequest {
    id?: number;
    name: string;
    description: string;
  }
  
  export interface CategoryUpdateOrInsertResponse {
    id: number;
    name: string;
    description: string;
    createdAt: Date;
    updatedAt: Date;
  }
  
  @Injectable({
    providedIn: 'root'
  })


  export class CategoryUpdateOrInsertEndpointService implements MyBaseEndpointAsync<CategoryUpdateOrInsertRequest, CategoryUpdateOrInsertResponse> {
    private apiUrl = `${MyConfig.api_address}/categories`;
  
    constructor(private httpClient: HttpClient) {
    }
  
    handleAsync(request: CategoryUpdateOrInsertRequest) {
      return this.httpClient.post<CategoryUpdateOrInsertResponse>(`${this.apiUrl}`, request);
    }
  }