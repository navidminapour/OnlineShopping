import { NgModule } from '@angular/core';
import { HomeSliderComponent } from './home-slider/home-slider.component';
import { HomeBlogComponent } from './home-blog/home-blog.component';
import { HomeGetInspiredComponent } from './home-get-inspired/home-get-inspired.component';
import { HomeHotComponent } from './home-hot/home-hot.component';
import { HomeAdvantagesComponent } from './home-advantages/home-advantages.component';
import { RouterModule } from '@angular/router';
import { HomeComponent } from './home.component';
import { CarouselModule } from 'ngx-owl-carousel-o';
import { HomeRoutingModule } from './home-routing.module';

@NgModule({
    declarations: [
        HomeComponent,
        HomeSliderComponent,
        HomeBlogComponent,
        HomeGetInspiredComponent,
        HomeHotComponent,
        HomeAdvantagesComponent,
    ],
    imports:[
        HomeRoutingModule,
        CarouselModule
    ]
})
export class HomeModule {

}