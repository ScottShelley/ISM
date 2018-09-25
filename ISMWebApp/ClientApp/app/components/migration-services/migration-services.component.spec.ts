import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MigrationServicesComponent } from './migration-services.component';

describe('MigrationServicesComponent', () => {
  let component: MigrationServicesComponent;
  let fixture: ComponentFixture<MigrationServicesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MigrationServicesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MigrationServicesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
