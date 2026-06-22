import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { SubcategoriesGetByIdResponse, SubcategoryGetByIdEndpointService } from '../../../../endpoints/subcategory-endpoints/subcategories-get-by-id-endpoint';
import { SubcategoryUpdateOrInsertEndpointService } from '../../../../endpoints/subcategory-endpoints/subcategories-update-or-insert-endpoint';
import { CategoryGetAllResponse, CategoryGetAllService } from '../../../../endpoints/category-endpoints/categories-get-all-endpoint';

@Component({
  selector: 'app-subcategory-edit',
  templateUrl: './subcategory-edit.component.html',
  styleUrls: ['./subcategory-edit.component.css']
})
export class SubcategoryEditComponent implements OnInit {
  subcategoryId: number;
  subcategory: SubcategoriesGetByIdResponse = {
    id: 0,
    name: '',
    description: '',
    categoryId: 0,
    createdAt: new Date(),
    updatedAt: new Date()
  };

  categories: CategoryGetAllResponse[] = [];
  submitted = false;  

  constructor(
    private route: ActivatedRoute,
    public router: Router,
    private subcategoryGetByIdService: SubcategoryGetByIdEndpointService,
    private subcategoryUpdateService: SubcategoryUpdateOrInsertEndpointService,
    private categoryGetAllService: CategoryGetAllService
  ) {
    this.subcategoryId = 0;
  }

  ngOnInit(): void {
    this.subcategoryId = Number(this.route.snapshot.paramMap.get('id'));
    if (this.subcategoryId) {
      this.loadSubcategoryData();
    }

    this.loadCategories();
  }

  loadCategories(): void {
    this.categoryGetAllService.handleAsync().subscribe({
      next: (categories: CategoryGetAllResponse[]) => {
        this.categories = categories;
        if (this.subcategoryId && this.subcategory?.categoryId) {
          const selectedCategory = this.categories.find(category => category.id === this.subcategory.categoryId);
          if (selectedCategory) {
            this.subcategory.categoryId = selectedCategory.id;
          }
        }
      },
      error: (error: any) => console.error('Error loading categories', error)
    });
  }

  loadSubcategoryData(): void {
    this.subcategoryGetByIdService.handleAsync(this.subcategoryId).subscribe({
      next: (subcategory: SubcategoriesGetByIdResponse) => {
        this.subcategory = subcategory;
      },
      error: (error: any) => console.error('Error loading subcategory data', error)
    });
  }

  onSubmit(subcategoryForm: any): void {
    this.submitted = true;  
    if (subcategoryForm.invalid) {
      return;
    }

    this.updateSubcategory();
  }

  updateSubcategory(): void {
    this.subcategoryUpdateService.handleAsync({
      id: this.subcategory.id,
      name: this.subcategory.name,
      description: this.subcategory.description,
      categoryId: this.subcategory.categoryId,
    }).subscribe({
      next: () => this.router.navigate(['/admin/subcategories']),
      error: (error: any) => console.error('Error updating subcategory', error)
    });
  }
}