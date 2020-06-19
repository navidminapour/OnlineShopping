import { Component, OnInit, ViewChild, OnDestroy, ElementRef } from '@angular/core';
import { ProductsService } from '../../products.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-product-detail-description',
  templateUrl: './product-detail-description.component.html',
  styleUrls: ['./product-detail-description.component.css']
})
export class ProductDetailDescriptionComponent implements OnInit, OnDestroy {
  private scrollSub: Subscription;
  @ViewChild("productDescription", { static: false }) private productDescriptionElement: ElementRef;
  constructor(private productsService: ProductsService) { }

  ngOnInit() {
    this.scrollSub = this.productsService.scrollToProductDescriptionClicked.subscribe(() => {
      this.productDescriptionElement.nativeElement.scrollIntoView({ behavior: 'smooth' });
    });
  }

  ngOnDestroy(){
    this.scrollSub.unsubscribe();
  }
}
