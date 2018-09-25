import { TestBed, inject } from '@angular/core/testing';

import { VisasService } from './visas.service';

describe('VisasService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [VisasService]
    });
  });

  it('should be created', inject([VisasService], (service: VisasService) => {
    expect(service).toBeTruthy();
  }));
});
