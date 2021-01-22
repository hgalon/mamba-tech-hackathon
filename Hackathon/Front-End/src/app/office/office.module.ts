import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OfficeModalComponent } from './office-modal/office-modal.component';
import { PoButtonModule, PoChartModule, PoInfoModule, PoModalModule, PoPageModule, PoTableModule, PoTagModule } from '@po-ui/ng-components';
import { OfficeSlideComponent } from './office-slide/office-slide.component';
import { NgCircleProgressModule } from 'ng-circle-progress';



@NgModule({
  declarations: [OfficeModalComponent, OfficeSlideComponent],
  imports: [
    CommonModule,
    PoPageModule,
    PoButtonModule,
    PoModalModule, 
    PoInfoModule,
    PoTagModule,
    PoTableModule,
    NgCircleProgressModule.forRoot({
      "radius": 60,
      "space": -10,
      "outerStrokeGradient": true,
      "outerStrokeWidth": 10,
      "outerStrokeColor": "#4882c2",
      "outerStrokeGradientStopColor": "#53a9ff",
      "innerStrokeColor": "#e7e8ea",
      "innerStrokeWidth": 10,
      "title": "85%",
      "subtitle": "Aderência%",
      "animateTitle": false,
      "animationDuration": 1000,
      "showUnits": false,
      "showBackground": false,
      "clockwise": false,
      "startFromZero": false,
      "lazy": true})
  ],
  exports:[OfficeModalComponent]
})
export class OfficeModule { }
