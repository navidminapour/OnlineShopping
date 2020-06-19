import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { HeaderComponent } from './layouts/header/header.component';
import { CurrentPageOrderComponent } from './layouts/current-page-order/current-page-order.component';
import { TopBarComponent } from './layouts/header/top-bar/top-bar.component';
import { NavbarComponent } from './layouts/header/navbar/navbar.component';
import { FooterComponent } from './layouts/footer/footer.component';
import { AppLayoutComponent } from './layouts/app-layout/app-layout.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CarouselModule } from 'ngx-owl-carousel-o';
import { CollapseModule } from 'ngx-bootstrap/collapse';
import { AppRoutingModule } from './app-routing.module';
import { SharedModule } from './shared/shared.module';
import { CoreModule } from './core.module';
import * as fromApp from "./store/app.reducer";
import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';
import { StoreDevtoolsModule } from "@ngrx/store-devtools";
import { OrderEffects } from './order/store/order.effects';
import { StoreRouterConnectingModule } from "@ngrx/router-store";
import { environment } from "../environments/environment";

@NgModule({
    declarations: [
        AppComponent,
        HeaderComponent,
        CurrentPageOrderComponent,
        TopBarComponent,
        NavbarComponent,
        FooterComponent,
        AppLayoutComponent
    ],
    imports: [
        BrowserModule.withServerTransition({ appId: "online-shopping-app" }),
        HttpClientModule,
        StoreModule.forRoot(fromApp.appReducer),
        EffectsModule.forRoot([OrderEffects]),
        StoreDevtoolsModule.instrument({ logOnly: environment.production }),
        StoreRouterConnectingModule.forRoot(),
        AppRoutingModule,
        BrowserAnimationsModule,
        CarouselModule,
        CollapseModule.forRoot(),
        SharedModule,
        CoreModule
    ],
    bootstrap: [AppComponent],
})
export class AppModule {
}
