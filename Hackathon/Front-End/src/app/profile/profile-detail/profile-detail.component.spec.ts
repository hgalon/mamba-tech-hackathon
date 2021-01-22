import { HttpClientModule } from "@angular/common/http";
import { async, ComponentFixture, TestBed, TestModuleMetadata } from '@angular/core/testing';
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { PoModule } from "@po-ui/ng-components";
import { of } from "rxjs";
import { ActivatedRouteMock } from "../../utils-test/router/activated-route.mock";
import { RouterMock } from "../../utils-test/router/routerFake.mock";

import { ProfileDetailComponent } from './profile-detail.component';

xdescribe('ProfileDetailComponent', () => {
  let component: ProfileDetailComponent;
  let fixture: ComponentFixture<ProfileDetailComponent>;

  const moduleDef: TestModuleMetadata = {
    imports: [FormsModule, ReactiveFormsModule, HttpClientModule, PoModule],
    providers: [
      {
        provide: ActivatedRoute,
        useValue: {
          paramMap: of({
            get: () => {
              return '1';
            }
          }),
          snapshot: {
            data: {
              dataProtected: ['screen']
            }
          }
        },
      },
      { provide: Router, useClass: RouterMock }
    ]
  }

  beforeEach(async(() => {
    TestBed.configureTestingModule(moduleDef)
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProfileDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
