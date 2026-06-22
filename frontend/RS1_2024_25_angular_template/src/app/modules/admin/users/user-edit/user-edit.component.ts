import {Component, OnInit} from '@angular/core';
import {ActivatedRoute, Router} from '@angular/router';
import { UserGetByIdEndpointService, UserGetByIdResponse } from '../../../../endpoints/user-endpoints/users-get-by-id-endpoint';
import { UserUpdateOrInsertEndpointService } from '../../../../endpoints/user-endpoints/users-update-or-insert-endpoint';


@Component({
  selector: 'app-user-edit',
  templateUrl: './user-edit.component.html',
  styleUrls: ['./user-edit.component.css']
})
export class UserEditComponent implements OnInit {
  userId: number;
  user: UserGetByIdResponse = {
    id: 0,
    firstName: '',
    lastName: '',
    email: '',
    password: '',
    phoneNumber: '',
    address: '',
    isAdmin: false,
    isManager: false,
    createdAt: new Date(),
    updatedAt: new Date()
  };

  constructor(
    private route: ActivatedRoute,
    public router: Router,
    private userGetByIdService: UserGetByIdEndpointService,
    private userUpdateService: UserUpdateOrInsertEndpointService
  ) {
    this.userId = 0;
  }

  ngOnInit(): void {
    this.userId = Number(this.route.snapshot.paramMap.get('id'));
    if (this.userId) {
      this.loadUserData();
    }
  }

  loadUserData(): void {
    this.userGetByIdService.handleAsync(this.userId).subscribe({
      next: (user: UserGetByIdResponse) => {
        this.user = user
      
      },
      error: (error: any) => console.error('Error loading user data', error)
    });
  }


  updateUser(): void {
    this.userUpdateService.handleAsync({
      id: this.user.id,
      firstName: this.user.firstName,
      lastName: this.user.lastName,
      email: this.user.email,
      password: this.user.password,
      phoneNumber: this.user.phoneNumber,
      address: this.user.address,
      isAdmin: this.user.isAdmin,
      isManager: this.user.isManager
    }).subscribe({
      next: () => this.router.navigate(['/admin/users']),
      error: (error: any) => console.error('Error updating user', error)
    });
  }
}



