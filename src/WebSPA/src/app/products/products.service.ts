import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class ProductsService {
    scrollToProductDescriptionClicked = new Subject<void>();
}