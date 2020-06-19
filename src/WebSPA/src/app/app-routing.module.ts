import { NgModule } from '@angular/core';
import { Routes, RouterModule, PreloadAllModules } from '@angular/router';
import { AppLayoutComponent } from './layouts/app-layout/app-layout.component';

const appRoutes: Routes = [
    { path: '', pathMatch:'full', loadChildren: () => import('./home/home.module').then(m => m.HomeModule) },
    {
        path: '', component: AppLayoutComponent, children: [
            { path: 'products', loadChildren: () => import('./products/products.module').then(m => m.ProductsModule) },
            { path: 'order', loadChildren: () => import('./order/order.module').then(m => m.OrderModule) },
            { path: 'customer', loadChildren: () => import('./customer/customer.module').then(m => m.CustomerModule) },
            { path: 'blog', loadChildren: () => import("./blog/blog.module").then(m => m.CustomerModule) },
            { path: 'page', loadChildren: () => import('./pages/pages.module').then(m => m.PagesModule) },
        ]
    },
    { path: '**', redirectTo: 'page/not-found' }
];
@NgModule({
    imports: [RouterModule.forRoot(appRoutes)],
    exports: [RouterModule]
})
export class AppRoutingModule {

}