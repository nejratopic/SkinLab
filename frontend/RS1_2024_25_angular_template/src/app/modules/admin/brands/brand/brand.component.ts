import { Component } from '@angular/core';
import {Router} from '@angular/router';
import {BrandGetAllResponse,BrandGetAllService} from '../../../../endpoints/brand-endpoints/brands-get-all-endpoint';
import { BrandDeleteEndpointService } from '../../../../endpoints/brand-endpoints/brands-delete-endpoint'; // ✅ Match the other import
@Component({
  selector: 'app-brand',
  templateUrl: './brand.component.html',
  styleUrl: './brand.component.css'
})
export class BrandComponent {
  brands: BrandGetAllResponse[] = [];

  constructor(
    private brandService: BrandGetAllService,
    private brandDeleteService: BrandDeleteEndpointService,
    private router: Router
  ) {
  }

  ngOnInit(): void {
    this.fetchBrand();
  }

  fetchBrand(): void {
    this.brandService.handleAsync().subscribe({
      next: (data) => (this.brands = data),
      error: (err) => console.error('Error fetching brands:', err)
    });
  }

  editBrand(id: number): void {
    this.router.navigate(['/admin/brand/edit', id]);
  }
  addBrand(): void {
    this.router.navigate(['/admin/brand/new']);
  }

  deleteBrand(id: number): void {
    if (confirm('Are you sure you want to delete this brand?')) {
      this.brandDeleteService.handleAsync(id).subscribe({
        next: () => {
          console.log(`Brand with ID ${id} deleted successfully`);
          this.brands = this.brands.filter(brands => brands.id !== id); // Uklanjanje iz lokalne liste
        },
        error: (err) => console.error('Error deleting brand:', err)
      });
    }
  }
}




