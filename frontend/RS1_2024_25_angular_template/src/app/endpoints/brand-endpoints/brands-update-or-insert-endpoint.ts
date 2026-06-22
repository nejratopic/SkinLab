import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {MyConfig} from '../../my-config';
import {MyBaseEndpointAsync} from '../../helper/my-base-endpoint-async.interface';

export interface BrandUpdateOrInsertRequest {
    id?: number;
    name: string;
    description: string;
  }

  export interface BrandUpdateOrInsertResponse {
    id: number;
    name: string;
    description: string;
    createdAt: Date;
    updatedAt: Date;
  }

  @Injectable({
    providedIn: 'root'
  })


  export class BrandUpdateOrInsertEndpointService implements MyBaseEndpointAsync<BrandUpdateOrInsertRequest, BrandUpdateOrInsertResponse> {
    private apiUrl = `${MyConfig.api_address}/brands`;

    constructor(private httpClient: HttpClient) {
    }

    handleAsync(request: BrandUpdateOrInsertRequest) {
      return this.httpClient.post<BrandUpdateOrInsertResponse>(`${this.apiUrl}`, request);
    }
  }
