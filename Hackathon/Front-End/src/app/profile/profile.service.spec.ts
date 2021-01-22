import { HttpClientModule } from "@angular/common/http";
import { TestBed, TestModuleMetadata } from '@angular/core/testing';

import { ProfileService } from './profile.service';

describe('ProfileService', () => {
  let service: ProfileService;

  const moduleDef: TestModuleMetadata = {
    imports: [
      HttpClientModule,
    ],
    providers: [
    ]
  }

  beforeEach(() => {
    TestBed.configureTestingModule(moduleDef);
    service = TestBed.inject(ProfileService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
