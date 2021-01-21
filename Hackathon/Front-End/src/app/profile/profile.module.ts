import { OfficeService } from '../office/office.service';
import { ProfileService } from './profile.service';
import { ProfileRoutingModule } from './profile-routing.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProfileDetailComponent } from './profile-detail/profile-detail.component';

import {
  PoPageModule,
  PoTableModule,
  PoDividerModule,
  PoFieldModule,
  PoInfoModule
} from '@po-ui/ng-components';
import { ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [ProfileDetailComponent],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    PoPageModule,
    PoTableModule,
    PoDividerModule,
    PoFieldModule,
    PoInfoModule,
    ProfileRoutingModule
  ],
  providers:[ProfileService, OfficeService]
})
export class ProfileModule { }
