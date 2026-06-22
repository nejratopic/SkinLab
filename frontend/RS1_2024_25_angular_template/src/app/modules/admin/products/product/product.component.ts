import { Component } from '@angular/core';
import {ProductGetAllResponse, ProductGetAllService} from '../../../../endpoints/product-endpoints/products-get-all-endpoint';
import {ProductDeleteEndpointService} from '../../../../endpoints/product-endpoints/products-delete-endpoint';
import {Router} from '@angular/router';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrl: './product.component.css'
})
export class ProductComponent {
  products: ProductGetAllResponse[] = [];

  constructor(
    private productService: ProductGetAllService,
    private productDeleteService: ProductDeleteEndpointService,
    private router: Router
  ) {
  }

  ngOnInit(): void {
    this.fetchProduct();
  }

  fetchProduct(): void {
    this.productService.handleAsync().subscribe({
      next: (data) => (this.products = data),
      error: (err) => console.error('Error fetching products:', err)
    });
  }

  editProduct(id: number): void {
    this.router.navigate(['/admin/product/edit', id]);
  }
  addProduct(): void {
    this.router.navigate(['/admin/product/new']);
  }

  deleteProduct(id: number): void {
    if (confirm('Are you sure you want to delete this product?')) {
      this.productDeleteService.handleAsync(id).subscribe({
        next: () => {
          console.log(`Product with ID ${id} deleted successfully`);
          this.products = this.products.filter(products => products.id !== id); // Uklanjanje iz lokalne liste
        },
        error: (err) => console.error('Error deleting product:', err)
      });
    }
  }
}


