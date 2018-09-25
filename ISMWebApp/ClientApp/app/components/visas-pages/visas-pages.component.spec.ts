import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { VisasPagesComponent } from './visas-pages.component';

describe('VisasPagesComponent', () => {
  let component: VisasPagesComponent;
  let fixture: ComponentFixture<VisasPagesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ VisasPagesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(VisasPagesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
