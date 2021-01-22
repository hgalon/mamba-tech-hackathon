import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OfficeModalComponent } from './office-modal/office-modal.component';
import { PoButtonModule, PoModalModule, PoPageModule } from '@po-ui/ng-components';
import { OfficeSlideComponent } from './office-slide/office-slide.component';



@NgModule({
  declarations: [OfficeModalComponent, OfficeSlideComponent],
  imports: [
    CommonModule,
    PoPageModule,
    PoButtonModule,
    PoModalModule
  ],
  exports:[OfficeModalComponent]
})
export class OfficeModule { }
