import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {MyConfig} from '../../my-config';
import {MyBaseEndpointAsync} from '../../helper/my-base-endpoint-async.interface';

export interface SubategoryUpdateOrInsertRequest {
    id?: number;
    name: string;
    categoryId: number;
    description: string;
  }
  
  export interface SubategoryUpdateOrInsertResponse {
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


  export class SubcategoryUpdateOrInsertEndpointService implements MyBaseEndpointAsync<SubategoryUpdateOrInsertRequest, SubategoryUpdateOrInsertResponse> {
    private apiUrl = `${MyConfig.api_address}/subcategories`;
  
    constructor(private httpClient: HttpClient) {
    }
  
    handleAsync(request: SubategoryUpdateOrInsertRequest) {
      return this.httpClient.post<SubategoryUpdateOrInsertResponse>(`${this.apiUrl}`, request);
    }
  }