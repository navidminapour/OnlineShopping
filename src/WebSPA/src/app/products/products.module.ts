import { NgModule } from '@angular/core';
import { ProductsComponent } from './products.component';
import { ProductListComponent } from './product-list/product-list.component';
import { ProductListHeaderComponent } from './product-list/product-list-header/product-list-header.component';
import { ProductsCategoryDescriptionComponent } from './product-list/products-category-description/products-category-description.component';
import { CategoryFilterComponent } from './products-filter/category-filter/category-filter.component';
import { ProductsFilterComponent } from './products-filter/products-filter.component';
import { BrandFilterComponent } from './products-filter/brand-filter/brand-filter.component';
import { ColourFilterComponent } from './products-filter/colour-filter/colour-filter.component';
import { ProductListPaginationComponent } from './product-list/product-list-pagination/product-list-pagination.component';
import { ProductDetailComponent } from './product-detail/product-detail.component';
import { ProductDetailImagesComponent } from './product-detail/product-detail-images/product-detail-images.component';
import { ProductDetailDescriptionComponent } from './product-detail/product-detail-description/product-detail-description.component';
import { CarouselModule } from 'ngx-owl-carousel-o';
import { RouterModule } from '@angular/router';
import { SharedModule } from '../shared/shared.module';
import { ProductsRoutingModule } from './products-routing.module';

@NgModule({
    declarations: [
        ProductsComponent,
        ProductListComponent,
        ProductListHeaderComponent,
        ProductsCategoryDescriptionComponent,
        CategoryFilterComponent,
        ProductsFilterComponent,
        BrandFilterComponent,
        ColourFilterComponent,
        ProductListPaginationComponent,
        ProductDetailComponent,
        ProductDetailImagesComponent,
        ProductDetailDescriptionComponent
    ],
    imports: [
        ProductsRoutingModule,
        CarouselModule,
        SharedModule
    ]
})
export class ProductsModule { }