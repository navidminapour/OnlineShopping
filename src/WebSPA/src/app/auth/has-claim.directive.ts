import { Directive, Input, TemplateRef, ViewContainerRef } from '@angular/core';
import { AuthService } from './auth.service';
import { Claim } from './claim.model';
import { take } from 'rxjs/operators';

@Directive({
    selector: '[hasClaim]'
})
export class HasClaimDirective {
    constructor(
        private templateRef: TemplateRef<any>,
        private viewContainer: ViewContainerRef,
        private authService: AuthService) { }

    @Input() set hasClaim(claim: Claim) {
        this.authService.hasClaim(claim.Type, claim.Value).pipe(take(1)).subscribe(hasClaim => {
            if (hasClaim)
                // Add template to DOM
                this.viewContainer.createEmbeddedView(this.templateRef);
            else
                // Remove template from DOM
                this.viewContainer.clear();
        })
    }
}
