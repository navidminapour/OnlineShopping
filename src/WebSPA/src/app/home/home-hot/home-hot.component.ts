import { Component, OnInit } from '@angular/core';
import { OwlOptions } from 'ngx-owl-carousel-o';

@Component({
  selector: 'app-home-hot',
  templateUrl: './home-hot.component.html',
  styleUrls: ['./home-hot.component.css']
})
export class HomeHotComponent implements OnInit {
  customOptions: OwlOptions = {
    items: 1,
    dots: true,
    nav: false,
    autoplay:true,
    loop:true,
    autoplayTimeout: 2500,

    responsive: {
      480: {
        items: 1
      },
      765: {
        items: 2
      },
      991: {
        items: 3
      },
      1200: {
        items: 5
      }
    }
  }
  constructor() { }

  ngOnInit() {
  }

}
