import { Component } from '@angular/core';
import {ActivatedRoute, Router} from '@angular/router';
import { BrandsGetByIdResponse, BrandGetByIdEndpointService } from '../../../../endpoints/brand-endpoints/brands-get-by-id-endpoint';
import { BrandUpdateOrInsertEndpointService } from '../../../../endpoints/brand-endpoints/brands-update-or-insert-endpoint';

@Component({
  selector: 'app-brand-edit',
  templateUrl: './brand-edit.component.html',
  styleUrl: './brand-edit.component.css'
})
export class BrandEditComponent {

  brandId: number;
  brand: BrandsGetByIdResponse = {
    id: 0,
    name: '',
    description: '',
    createdAt: new Date(),
    updatedAt: new Date()
  };

  constructor(
    private route: ActivatedRoute,
    public router: Router,
    private brandGetByIdService: BrandGetByIdEndpointService,
    private brandUpdateService: BrandUpdateOrInsertEndpointService
  ) {
    this.brandId = 0;
  }

  ngOnInit(): void {
    this.brandId = Number(this.route.snapshot.paramMap.get('id'));
    if (this.brandId) {
      this.loadBrandData();
    }
  }

  loadBrandData(): void {
    this.brandGetByIdService.handleAsync(this.brandId).subscribe({
      next: (brand: BrandsGetByIdResponse) => {
        this.brand = brand

      },
      error: (error: any) => console.error('Error loading brand data', error)
    });
  }


  // Update brand if form is valid
  onSubmit(): void {
    if (this.brand.name && this.brand.description) {
      this.updateBrand(); // Call the update function if valid
    } else {
      console.log('Form is invalid');
    }
  }

  updateBrand(): void {
    this.brandUpdateService.handleAsync({
      id: this.brand.id,
      name: this.brand.name,
      description: this.brand.description,
    }).subscribe({
      next: () => this.router.navigate(['/admin/brands']),
      error: (error: any) => console.error('Error updating brand', error)
    });
  }


}


