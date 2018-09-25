import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EducationServicesComponent } from './education-services.component';

describe('EducationServicesComponent', () => {
  let component: EducationServicesComponent;
  let fixture: ComponentFixture<EducationServicesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EducationServicesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EducationServicesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
