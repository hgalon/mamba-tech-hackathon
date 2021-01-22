import { HttpClientModule } from "@angular/common/http";
import { async, ComponentFixture, TestBed, TestModuleMetadata } from '@angular/core/testing';
import { PoModule } from "@po-ui/ng-components";

import { OfficeModalComponent } from './office-modal.component';

describe('OfficeModalComponent', () => {
  let component: OfficeModalComponent;
  let fixture: ComponentFixture<OfficeModalComponent>;

  const moduleDef: TestModuleMetadata = {
    imports: [
      HttpClientModule,
      PoModule,
    ],
    providers: [

    ]
  }

  beforeEach(async(() => {
    TestBed.configureTestingModule(moduleDef)
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(OfficeModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
