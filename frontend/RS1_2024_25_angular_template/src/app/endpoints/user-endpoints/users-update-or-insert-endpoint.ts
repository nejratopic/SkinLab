import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {MyConfig} from '../../my-config';
import {MyBaseEndpointAsync} from '../../helper/my-base-endpoint-async.interface';

export interface UserUpdateOrInsertRequest {
  id?: number;  
  firstName: string;
  lastName: string;
  email: string;
  password: string;
  phoneNumber: string;
  address: string;
  isAdmin: boolean;
  isManager: boolean;
}

export interface UserUpdateOrInsertResponse {
  id: number;
  firstName: string;
  lastName: string;
  email: string;
  password: string;
  phoneNumber: string;
  address: string;
  isAdmin: boolean;
  isManager: boolean;
  createdAt: Date;
  updatedAt: Date;
}

@Injectable({
  providedIn: 'root'
})
export class UserUpdateOrInsertEndpointService implements MyBaseEndpointAsync<UserUpdateOrInsertRequest, UserUpdateOrInsertResponse> {
  private apiUrl = `${MyConfig.api_address}/users`;

  constructor(private httpClient: HttpClient) {
  }

  handleAsync(request: UserUpdateOrInsertRequest) {
    return this.httpClient.post<UserUpdateOrInsertResponse>(`${this.apiUrl}`, request);
  }
}