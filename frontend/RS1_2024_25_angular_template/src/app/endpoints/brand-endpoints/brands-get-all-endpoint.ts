import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {MyConfig} from '../../my-config';
import {MyBaseEndpointAsync} from '../../helper/my-base-endpoint-async.interface';

export interface BrandGetAllResponse {
  id: number;
  name: string;
  description: string;
  createdAt: string;
  updatedAt: string;
}

@Injectable({
  providedIn: 'root'
})
export class BrandGetAllService implements MyBaseEndpointAsync<void, BrandGetAllResponse[]> {
  private apiUrl = `${MyConfig.api_address}/brands/all`;

  constructor(private httpClient: HttpClient) {
  }



  handleAsync() {
    return this.httpClient.get<BrandGetAllResponse[]>(`${this.apiUrl}`);
  }
}
