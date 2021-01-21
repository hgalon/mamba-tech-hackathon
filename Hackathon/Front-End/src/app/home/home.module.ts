import { OfficeService } from './../office/office.service';
import { OfficeModule } from './../office/office.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PoButtonModule, PoPageModule, PoModalModule, PoTagModule } from '@po-ui/ng-components';

import { HomeComponent } from './home.component';
import { HomeRoutingModule } from './home-routing.module';

@NgModule({
  declarations: [HomeComponent],
  imports: [
    CommonModule,
    PoPageModule,
    HomeRoutingModule,
    PoButtonModule,
    OfficeModule, 
    PoModalModule,
    PoTagModule
  ],
  providers:[OfficeService]
})
export class HomeModule { }
