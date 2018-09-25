import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TurkeyOfficeComponent } from './turkey-office.component';

describe('TurkeyOfficeComponent', () => {
  let component: TurkeyOfficeComponent;
  let fixture: ComponentFixture<TurkeyOfficeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TurkeyOfficeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TurkeyOfficeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
