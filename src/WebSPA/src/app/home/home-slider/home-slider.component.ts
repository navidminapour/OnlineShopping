import { Component, OnInit } from '@angular/core';
import { OwlOptions } from 'ngx-owl-carousel-o';

@Component({
  selector: 'app-home-slider',
  templateUrl: './home-slider.component.html',
  styleUrls: ['./home-slider.component.css']
})
export class HomeSliderComponent implements OnInit {
  customOptions: OwlOptions = {
    items: 1,
    nav: false,
    dots: true,
    autoplay: true,
    autoplayHoverPause: true,
    dotsSpeed: 400,
    loop: true,
    responsive: {
      0: {
        items: 1
      }
    }
  }

  constructor() { }

  ngOnInit() {
  }

}
