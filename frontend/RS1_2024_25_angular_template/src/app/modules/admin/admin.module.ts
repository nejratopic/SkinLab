import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {AdminRoutingModule} from './admin-routing.module';
import {AdminLayoutComponent} from './admin-layout/admin-layout.component';
import {UsersComponent} from './users/users.component';
import {FormsModule} from '@angular/forms';
import {SharedModule} from '../shared/shared.module';
import { UserEditComponent } from './users/user-edit/user-edit.component';
import { CategoryEditComponent } from './categories/category-edit/category-edit.component';
import { CategoriesComponent } from './categories/categories.component';
import { SubcategoryEditComponent } from './subcategories/subcategories-edit/subcategory-edit.component';
import { BrandComponent } from './brands/brand/brand.component';
import { ProductComponent } from './products/product/product.component';
import { BrandEditComponent } from './brands/brand-edit/brand-edit.component';
import { ProductEditComponent } from './products/product-edit/product-edit.component';


@NgModule({
  declarations: [
    AdminLayoutComponent,
    UsersComponent,
    UserEditComponent,
    CategoriesComponent,
    CategoryEditComponent,
    BrandEditComponent,
    ProductEditComponent,
    SubcategoryEditComponent,
    BrandComponent,
    ProductComponent,
    BrandEditComponent,
    ProductEditComponent
  ],
  imports: [
    CommonModule,
    AdminRoutingModule,
    FormsModule,
    SharedModule // Omogućava pristup svemu što je eksportovano iz SharedModule
  ],
  providers: []
})
export class AdminModule {
}
