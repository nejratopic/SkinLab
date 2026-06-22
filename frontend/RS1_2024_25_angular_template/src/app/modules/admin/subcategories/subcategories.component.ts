import {Component} from '@angular/core';
import {Router} from '@angular/router';
import { SubcategoryGetAllResponse, SubcategoryGetAllService } from '../../../endpoints/subcategory-endpoints/subcategories-get-all-endpoint';
import { SubcategoryDeleteEndpointService } from '../../../endpoints/subcategory-endpoints/subcategories-delete-endpoint';


@Component({
  selector: 'app-subcategories',
  templateUrl: './subcategories.component.html',
  styleUrls: ['./subcategories.component.css']
})
export class SubcategoriesComponent {
    subcategories: SubcategoryGetAllResponse[] = [];

  constructor(
    private subcategoryService: SubcategoryGetAllService,
    private subcategoryDeleteService: SubcategoryDeleteEndpointService,
    private router: Router
  ) {
  }

  ngOnInit(): void {
    this.fetchSubcategories();
  }

  fetchSubcategories(): void {
    this.subcategoryService.handleAsync().subscribe({
      next: (data) => (this.subcategories = data),
      error: (err) => console.error('Error fetching subcategories:', err)
    });
  }

  editSubcategory(id: number): void {
    this.router.navigate(['/admin/subcategory/edit', id]);
  }
  addSubcategory(): void {
    this.router.navigate(['/admin/subcategory/new']);
  }

  deleteSubcategory(id: number): void {
    if (confirm('Are you sure you want to delete this subcategory?')) {
      this.subcategoryDeleteService.handleAsync(id).subscribe({
        next: () => {
          console.log(`Subatgeory with ID ${id} deleted successfully`);
          this.subcategories = this.subcategories.filter(subcategories => subcategories.id !== id); // Uklanjanje iz lokalne liste
        },
        error: (err) => console.error('Error deleting subcategory:', err)
      });
    }
  }
}
