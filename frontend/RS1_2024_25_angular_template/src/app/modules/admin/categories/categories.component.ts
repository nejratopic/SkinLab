import {Component} from '@angular/core';
import {Router} from '@angular/router';
import { CategoryGetAllResponse, CategoryGetAllService } from '../../../endpoints/category-endpoints/categories-get-all-endpoint';
import { CategoryDeleteEndpointService } from '../../../endpoints/category-endpoints/categories-delete-endpoint';


@Component({
  selector: 'app-categories',
  templateUrl: './categories.component.html',
  styleUrls: ['./categories.component.css']
})
export class CategoriesComponent {
  categories: CategoryGetAllResponse[] = [];

  constructor(
    private categoryService: CategoryGetAllService,
    private categoryDeleteService: CategoryDeleteEndpointService,
    private router: Router
  ) {
  }

  ngOnInit(): void {
    this.fetchCategories();
  }

  fetchCategories(): void {
    this.categoryService.handleAsync().subscribe({
      next: (data) => (this.categories = data),
      error: (err) => console.error('Error fetching categories:', err)
    });
  }

  editCategory(id: number): void {
    this.router.navigate(['/admin/category/edit', id]);
  }
  addCategory(): void {
    this.router.navigate(['/admin/category/new']);
  }

  deleteCategory(id: number): void {
    if (confirm('Are you sure you want to delete this category?')) {
      this.categoryDeleteService.handleAsync(id).subscribe({
        next: () => {
          console.log(`Catgeory with ID ${id} deleted successfully`);
          this.categories = this.categories.filter(categories => categories.id !== id); // Uklanjanje iz lokalne liste
        },
        error: (err) => console.error('Error deleting category:', err)
      });
    }
  }
}
