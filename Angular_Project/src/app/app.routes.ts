import { Routes } from '@angular/router';
import { ProductComponent } from './website/product/product.component';
import { ProductDetailComponent } from './website/product/product-detail/product-detail.component';

export const routes: Routes = [
    {path: '', component: ProductComponent},
    {path: 'product', component: ProductComponent},
    {path: 'product/:id', component: ProductDetailComponent},
];
