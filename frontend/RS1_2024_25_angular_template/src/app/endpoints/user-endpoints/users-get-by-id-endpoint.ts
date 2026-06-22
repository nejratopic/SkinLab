import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {MyConfig} from '../../my-config';
import {MyBaseEndpointAsync} from '../../helper/my-base-endpoint-async.interface';

export interface UserGetByIdResponse {
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
export class UserGetByIdEndpointService implements MyBaseEndpointAsync<number, UserGetByIdResponse> {
  private apiUrl = `${MyConfig.api_address}/users`;

  constructor(private httpClient: HttpClient) {
  }

  handleAsync(id: number) {
    return this.httpClient.get<UserGetByIdResponse>(`${this.apiUrl}/${id}`);
  }
}
