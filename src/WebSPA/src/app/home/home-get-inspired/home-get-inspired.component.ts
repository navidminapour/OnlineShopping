import { Component, OnInit } from '@angular/core';
import { OwlOptions } from 'ngx-owl-carousel-o';

@Component({
  selector: 'app-home-get-inspired',
  templateUrl: './home-get-inspired.component.html',
  styleUrls: ['./home-get-inspired.component.css']
})
export class HomeGetInspiredComponent implements OnInit {
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
