import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ContentLayoutComponent } from './layout/content-layout/content-layout.component';
import { CoreLayoutComponent } from './layout/core-layout/core-layout.component';
import { FooterComponent } from './layout/footer/footer.component';
import { NavbarComponent } from './layout/navbar/navbar.component';
import { SpinnerComponent } from './shared/components/spinner/spinner.component';
import {PagesModule} from "./module/pages.module";
import {SharedModule} from "./shared/shared.module";

@NgModule({
  declarations: [
    AppComponent,
    ContentLayoutComponent,
    CoreLayoutComponent,
    FooterComponent,
    NavbarComponent,
    SpinnerComponent,
  ],
  imports: [
    PagesModule,
    BrowserModule.withServerTransition({appId: 'serverApp'}),
    AppRoutingModule,
    SharedModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
