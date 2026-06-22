import {Component} from '@angular/core';
import {Router} from '@angular/router';
import { UserGetAllResponse, UserGetAllService } from '../../../endpoints/user-endpoints/users-get-all-endpoint.service';
import { UserDeleteEndpointService } from '../../../endpoints/user-endpoints/users-delete-endpoint';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent {
  users: UserGetAllResponse[] = [];

  constructor(
    private userService: UserGetAllService,
    private userDeleteService: UserDeleteEndpointService,
    private router: Router
  ) {
  }

  ngOnInit(): void {
    this.fetchUsers();
  }

  fetchUsers(): void {
    this.userService.handleAsync().subscribe({
      next: (data) => (this.users = data),
      error: (err) => console.error('Error fetching users:', err)
    });
  }

  editUser(id: number): void {
    this.router.navigate(['/admin/user/edit', id]);
  }
  addUser(): void {
    this.router.navigate(['/admin/user/new']);
  }

  deleteUser(id: number): void {
    if (confirm('Are you sure you want to delete this user?')) {
      this.userDeleteService.handleAsync(id).subscribe({
        next: () => {
          console.log(`User with ID ${id} deleted successfully`);
          this.users = this.users.filter(user => user.id !== id); // Uklanjanje iz lokalne liste
        },
        error: (err) => console.error('Error deleting user:', err)
      });
    }
  }
}
