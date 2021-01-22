import { HttpClientModule } from "@angular/common/http";
import { TestBed, TestModuleMetadata } from '@angular/core/testing';
import { PoModule } from "@po-ui/ng-components";

import { OfficeService } from './office.service';

describe('OfficeService', () => {
  let service: OfficeService;

  const moduleDef: TestModuleMetadata = {
    imports: [
      HttpClientModule,
      PoModule,
    ],
    providers: [

    ]
  }

  beforeEach(() => {
    TestBed.configureTestingModule(moduleDef);
    service = TestBed.inject(OfficeService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
