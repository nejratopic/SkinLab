import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {MyConfig} from '../../my-config';
import {MyBaseEndpointAsync} from '../../helper/my-base-endpoint-async.interface';

export interface UserGetAllResponse {
    id: number;
    firstName: string;
    lastName: string;
    email: string;
    password: string;
    phoneNumber: string;
    address: string;
    createdAt: string; 
    updatedAt: string; 
    isAdmin: boolean;
    isManager: boolean;
  }
  
@Injectable({
  providedIn: 'root'
})
export class UserGetAllService implements MyBaseEndpointAsync<void, UserGetAllResponse[]> {
  private apiUrl = `${MyConfig.api_address}/users/all`;

  constructor(private httpClient: HttpClient) {
  }



  handleAsync() {
    return this.httpClient.get<UserGetAllResponse[]>(`${this.apiUrl}`);
  }
}
