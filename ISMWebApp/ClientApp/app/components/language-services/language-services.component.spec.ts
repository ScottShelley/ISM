import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LanguageServicesComponent } from './language-services.component';

describe('LanguageServicesComponent', () => {
  let component: LanguageServicesComponent;
  let fixture: ComponentFixture<LanguageServicesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LanguageServicesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LanguageServicesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
