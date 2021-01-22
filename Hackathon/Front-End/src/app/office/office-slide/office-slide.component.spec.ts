import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { OfficeSlideComponent } from './office-slide.component';

describe('OfficeSlideComponent', () => {
  let component: OfficeSlideComponent;
  let fixture: ComponentFixture<OfficeSlideComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ OfficeSlideComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(OfficeSlideComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
