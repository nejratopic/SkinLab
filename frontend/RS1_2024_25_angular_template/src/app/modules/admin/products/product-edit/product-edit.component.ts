import { Component } from '@angular/core';
import {ActivatedRoute, Router} from '@angular/router';
import { ProductsGetByIdResponse, ProductGetByIdEndpointService } from '../../../../endpoints/product-endpoints/products-get-by-id-endpoint';
import { ProductUpdateOrInsertEndpointService } from '../../../../endpoints/product-endpoints/products-update-or-insert-endpoint';

@Component({
  selector: 'app-product-edit',
  templateUrl: './product-edit.component.html',
  styleUrl: './product-edit.component.css'
})
export class ProductEditComponent {

  productId: number;
  product: ProductsGetByIdResponse = {
    id: 0,
    name: '',
    description: '',
    createdAt: new Date().toISOString(),
    updatedAt: new Date().toISOString(),
    price:0,
    stockQuantity: 0,
    packSize: '',
    ingredients: '',
    howToUse:'',
    skinTypeId:0,
    subcategoryId:0,
    brandId:0,
    productTypeId:0,
    categoryId:0
  };

  constructor(
    private route: ActivatedRoute,
    public router: Router,
    private productGetByIdService: ProductGetByIdEndpointService,
    private productUpdateService: ProductUpdateOrInsertEndpointService
  ) {
    this.productId = 0;
  }

  ngOnInit(): void {
    this.productId = Number(this.route.snapshot.paramMap.get('id'));
    if (this.productId) {
      this.loadProductData();
    }
  }

  loadProductData(): void {
    this.productGetByIdService.handleAsync(this.productId).subscribe({
      next: (product: ProductsGetByIdResponse) => {
        this.product = product

      },
      error: (error: any) => console.error('Error loading product data', error)
    });
  }


  // Update product if form is valid
  onSubmit(): void {
    if (this.product.name && this.product.description) {
      this.updateProduct(); // Call the update function if valid
    } else {
      console.log('Form is invalid');
    }
  }

  updateProduct(): void {
    this.productUpdateService.handleAsync({
      id: this.product.id,
      name: this.product.name,
      description: this.product.description,
    }).subscribe({
      next: () => this.router.navigate(['/admin/products']),
      error: (error: any) => console.error('Error updating product', error)
    });
  }


}


