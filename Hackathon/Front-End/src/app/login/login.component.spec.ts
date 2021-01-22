import { HttpClientModule } from "@angular/common/http";
import { async, ComponentFixture, TestBed, TestModuleMetadata } from '@angular/core/testing';
import { ActivatedRoute, Router } from "@angular/router";
import { PoModule } from "@po-ui/ng-components";
import { ActivatedRouteMock } from "../utils-test/router/activated-route.mock";
import { RouterMock } from "../utils-test/router/routerFake.mock";

import { LoginComponent } from './login.component';

describe('LoginComponent', () => {
  let component: LoginComponent;
  let fixture: ComponentFixture<LoginComponent>;

  const moduleDef: TestModuleMetadata = {
    imports: [PoModule, HttpClientModule],
    providers: [
      { provide: ActivatedRoute, useClass: ActivatedRouteMock },
      { provide: Router, useClass: RouterMock }
    ]
  }

  beforeEach(async(() => {
    TestBed.configureTestingModule(moduleDef)
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LoginComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
