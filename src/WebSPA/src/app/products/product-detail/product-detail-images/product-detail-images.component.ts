import { Component, OnInit, ViewChild, Output, EventEmitter, AfterViewInit } from '@angular/core';
import { OwlOptions, SlidesOutputData, CarouselComponent, CarouselSlideDirective } from 'ngx-owl-carousel-o';
import { ProductsService } from '../../products.service';
import { SlideModel } from 'ngx-owl-carousel-o/lib/models/slide.model';

@Component({
  selector: 'app-product-detail-images',
  templateUrl: './product-detail-images.component.html',
  styleUrls: ['./product-detail-images.component.css']
})
export class ProductDetailImagesComponent implements OnInit, AfterViewInit {
  private slides: string[];
  slideClasses: string[] = ["active"];
  @Output() goToDescription = new EventEmitter<void>();
  @ViewChild("owlCar", { static: false }) owlCar: CarouselComponent;
  customOptions: OwlOptions = {
    items: 1,
    nav: false,
    dots: false,
    loop: true,
    autoplay: true,

    responsive: {
      0: {
        items: 1
      }
    }
  };

  constructor(private productsService: ProductsService) { }

  ngOnInit() {

  }

  ngAfterViewInit() {
    this.slides = this.owlCar.slides.toArray().map(result => result.id);
  }

  onCarouselChanged(data: SlidesOutputData) {
    if(data.slides.length){
      this.slideClasses = this.slides.map(i => (i === data.slides[0].id ? "active" : ""));
    }
  }

  changeSlide(index: number) {
    const id = this.slides[index];
    this.owlCar.to(id);
  }

  descriptionClicked() {
    this.productsService.scrollToProductDescriptionClicked.next();
  }
}
