import { NgModule } from '@angular/core';
import { ProductItemComponent } from '../products/product-list/product-item/product-item.component';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { ProductsSuggestionComponent } from '../products/products-suggestion/products-suggestion.component';
import { ProductsSuggestionItemComponent } from '../products/products-suggestion/products-suggestion-item/products-suggestion-item.component';
import { HasClaimDirective } from '../auth/has-claim.directive';

@NgModule({
    declarations:[
        ProductItemComponent,
        ProductsSuggestionComponent,
        ProductsSuggestionItemComponent,
        HasClaimDirective
    ],
    imports:[
        CommonModule,
        RouterModule
    ],
    exports:[
        CommonModule,
        ProductItemComponent,
        ProductsSuggestionComponent,
        ProductsSuggestionItemComponent,
        HasClaimDirective
    ]
})
export class SharedModule { }