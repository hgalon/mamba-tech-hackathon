import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OfficeModalComponent } from './office-modal/office-modal.component';
import { PoButtonModule, PoModalModule, PoPageModule } from '@po-ui/ng-components';



@NgModule({
  declarations: [OfficeModalComponent],
  imports: [
    CommonModule,
    PoPageModule,
    PoButtonModule,
    PoModalModule
  ],
  exports:[OfficeModalComponent]
})
export class OfficeModule { }
