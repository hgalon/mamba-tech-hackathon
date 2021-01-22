import { TestBed, inject, TestModuleMetadata } from '@angular/core/testing';
import { Router } from "@angular/router";
import { RouterMock } from "../../utils-test/router/routerFake.mock";

import { AuthGuard } from './auth.guard';

describe('AuthGuard', () => {

  const moduleDef: TestModuleMetadata = {
    providers: [
      { provide: Router, useClass: RouterMock }
    ]
  }

  beforeEach(() => {
    TestBed.configureTestingModule(
      moduleDef
    );
  });

  it('should ...', inject([AuthGuard], (guard: AuthGuard) => {
    expect(guard).toBeTruthy();
  }));
});
