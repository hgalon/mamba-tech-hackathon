import { HttpClientModule } from "@angular/common/http";
import { async, ComponentFixture, TestBed, TestModuleMetadata } from '@angular/core/testing';
import { Router } from "@angular/router";
import { PoModule } from "@po-ui/ng-components";
import { RouterMock } from "../utils-test/router/routerFake.mock";

import { HomeComponent } from './home.component';

describe('HomeComponent', () => {
  let component: HomeComponent;
  let fixture: ComponentFixture<HomeComponent>;

  const moduleDef: TestModuleMetadata = {
    imports: [
      HttpClientModule,
      PoModule,
    ],
    providers: [
      { provide: Router, useClass: RouterMock }
    ]
  }

  beforeEach(async(() => {
    TestBed.configureTestingModule(moduleDef);

    TestBed.compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HomeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('restore', () => {
    component.restore();
    expect(component.size).toBeUndefined();
    expect(component.content).toBeUndefined();
    expect(component.title).toEqual('PO Modal');
    expect(component.primaryActionLabel).toBeUndefined();
    expect(component.primaryActionProperties.length).toEqual(0);
    expect(component.secondaryActionLabel).toBeUndefined();
    expect(component.secondaryActionProperties.length).toEqual(0);
  });

  describe('filterFunction', () => {
    it('Caso nível coincida com as áreas fornecidas', () => {
      const areas = [
        {
          cargos: [
            {
              idNivel: 1
            }
          ]
        }
      ];
      const res = component.filterFunction(areas, 1);
      expect(res[0].idNivel).toEqual(areas[0].cargos[0].idNivel);
    });

    it('Caso nível não coincida com as áreas fornecidas', () => {
      const areas = [
        {
          cargos: [
            {
              idNivel: 11
            }
          ]
        }
      ];
      const res = component.filterFunction(areas, 1);
      expect(res.length).toEqual(0);
    });
  });

});
