import {Component, OnInit} from '@angular/core';
import {ActivatedRoute, Router} from '@angular/router';
import { CategoriesGetByIdResponse, CategoryGetByIdEndpointService } from '../../../../endpoints/category-endpoints/categories-get-by-id-endpoint';
import { CategoryUpdateOrInsertEndpointService } from '../../../../endpoints/category-endpoints/categories-update-or-insert-endpoint';


@Component({
  selector: 'app-category-edit',
  templateUrl: './category-edit.component.html',
  styleUrls: ['./category-edit.component.css']
})
export class CategoryEditComponent implements OnInit {
    categoryId: number;
    category: CategoriesGetByIdResponse = {
    id: 0,
    name: '',
    description: '',
    createdAt: new Date(),
    updatedAt: new Date()
  };

  constructor(
    private route: ActivatedRoute,
    public router: Router,
    private categoryGetByIdService: CategoryGetByIdEndpointService,
    private categoryUpdateService: CategoryUpdateOrInsertEndpointService
  ) {
    this.categoryId = 0;
  }

  ngOnInit(): void {
    this.categoryId = Number(this.route.snapshot.paramMap.get('id'));
    if (this.categoryId) {
      this.loadCategoryData();
    }
  }

  loadCategoryData(): void {
    this.categoryGetByIdService.handleAsync(this.categoryId).subscribe({
      next: (category: CategoriesGetByIdResponse) => {
        this.category = category
      
      },
      error: (error: any) => console.error('Error loading category data', error)
    });
  }

 
  // Update category if form is valid
  onSubmit(): void {
    if (this.category.name && this.category.description) {
      this.updateCategory(); // Call the update function if valid
    } else {
      console.log('Form is invalid');
    }
  }

  updateCategory(): void {
    this.categoryUpdateService.handleAsync({
      id: this.category.id,
      name: this.category.name,
      description: this.category.description,
    }).subscribe({
      next: () => this.router.navigate(['/admin/categories']),
      error: (error: any) => console.error('Error updating category', error)
    });
  }

  
}
