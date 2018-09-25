import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ThailandOfficeComponent } from './thailand-office.component';

describe('ThailandOfficeComponent', () => {
  let component: ThailandOfficeComponent;
  let fixture: ComponentFixture<ThailandOfficeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ThailandOfficeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ThailandOfficeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
