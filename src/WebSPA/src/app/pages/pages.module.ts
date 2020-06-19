import { NgModule } from '@angular/core';
import { NotFoundComponent } from './not-found/not-found.component';
import { UnauthorizedComponent } from './unauthorized/unauthorized.component';
import { ForbiddenComponent } from './forbidden/forbidden.component';
import { ContactComponent } from './contact/contact.component';
import { FaqComponent } from './faq/faq.component';
import { PagesRoutingModule } from './pages-routing.module';


@NgModule({
    declarations:[
        NotFoundComponent,
        UnauthorizedComponent,
        ForbiddenComponent,
        ContactComponent,
        FaqComponent
    ],
    imports:[
        PagesRoutingModule
    ]
})
export class PagesModule{}