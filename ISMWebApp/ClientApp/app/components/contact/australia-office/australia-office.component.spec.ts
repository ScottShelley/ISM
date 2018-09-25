import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AustraliaOfficeComponent } from './australia-office.component';

describe('AustraliaOfficeComponent', () => {
  let component: AustraliaOfficeComponent;
  let fixture: ComponentFixture<AustraliaOfficeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AustraliaOfficeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AustraliaOfficeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
