import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {AdminLayoutComponent} from './admin-layout/admin-layout.component';
import {DestinationComponent} from './destination/destination.component';
import {DashboardComponent} from './dashboard/dashboard.component';
import {ReservationComponent} from './reservation/reservation.component';
import {AdminErrorPageComponent} from './admin-error-page/admin-error-page.component';
import { UsersComponent } from './users/users.component';
import { UserEditComponent } from './users/user-edit/user-edit.component';
import { CategoryEditComponent } from './categories/category-edit/category-edit.component';
import { CategoriesComponent } from './categories/categories.component';
import { SubcategoriesComponent } from './subcategories/subcategories.component';
import { SubcategoryEditComponent } from './subcategories/subcategories-edit/subcategory-edit.component';
import {BrandComponent} from './brands/brand/brand.component';
import {ProductComponent} from './products/product/product.component';
import {BrandEditComponent} from './brands/brand-edit/brand-edit.component';
import {ProductEditComponent} from './products/product-edit/product-edit.component';
const routes: Routes = [
  {
    path: '',
    component: AdminLayoutComponent,
    children: [
      {path: '', redirectTo: 'dashboard', pathMatch: 'full'},
      {path: 'dashboard', component: DashboardComponent},
      {path: 'users', component: UsersComponent},
      {path: 'user/new', component: UserEditComponent},
      {path: 'user/edit/:id', component: UserEditComponent},
      {path: 'categories', component: CategoriesComponent},
      { path: 'category/new', component: CategoryEditComponent },
      { path: 'product/new', component: ProductEditComponent },
      { path: 'brand/new', component: BrandEditComponent },
      {path: 'category/edit/:id', component: CategoryEditComponent},
      {path: 'product/edit/:id', component: ProductEditComponent},
      {path: 'brand/edit/:id', component: BrandEditComponent},
      {path: 'subcategories', component: SubcategoriesComponent},
      {path: 'brands', component: BrandComponent},
      {path: 'products', component: ProductComponent},
      { path: 'subcategory/new', component: SubcategoryEditComponent },
      {path: 'subcategory/edit/:id', component: SubcategoryEditComponent},
      {path: 'destination', component: DestinationComponent},
      {path: 'order', component: ReservationComponent},
      {path: '**', component: AdminErrorPageComponent} // Default ruta
    ]
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule {
}
