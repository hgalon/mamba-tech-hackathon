import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PoButtonModule, PoPageModule } from '@po-ui/ng-components';

import { HomeComponent } from './home.component';
import { HomeRoutingModule } from './home-routing.module';

@NgModule({
  declarations: [HomeComponent],
  imports: [
    CommonModule,
    PoPageModule,
    HomeRoutingModule,
    PoButtonModule
  ]
})
export class HomeModule { }
