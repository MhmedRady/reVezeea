import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {ContentLayoutComponent} from "./layout/content-layout/content-layout.component";
import {HomeComponent} from "./module/home/home.component";

const routes: Routes = [
  {path: '', component: ContentLayoutComponent, children: [
      {path: '', redirectTo:'home', pathMatch: 'full'},
      {path: 'home', title: 'home', component: HomeComponent},
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {
    initialNavigation: 'enabledBlocking'
})],
  exports: [RouterModule]
})
export class AppRoutingModule { }
