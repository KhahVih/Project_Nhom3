import { Routes } from '@angular/router';
import { ProductComponent } from './website/product/product.component';
import { ProductDetailComponent } from './website/product/product-detail/product-detail.component';
import { ContactComponent } from './website/contact/contact.component';
import { RegisterComponent } from './website/register/register.component';
import { LoginComponent } from './website/login/login.component';
import { ForgotPasswordComponent } from './website/forgot-password/forgot-password.component';  

export const routes: Routes = [
    {path: '', component: ProductComponent},
    {path: 'product', component: ProductComponent},
    {path: 'product/:id', component: ProductDetailComponent},
    {path: 'contact', component: ContactComponent},
    {path: 'register', component: RegisterComponent},
    {path: 'login', component: LoginComponent},
    {path: 'forgot-password', component: ForgotPasswordComponent},
];
