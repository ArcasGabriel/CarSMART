import { TestBed } from '@angular/core/testing';

import { VechicleService } from './vechicle.service';

describe('VechicleService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: VechicleService = TestBed.get(VechicleService);
    expect(service).toBeTruthy();
  });
});
