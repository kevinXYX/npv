import { TestBed, inject } from '@angular/core/testing';

import { CalculationServiceService } from './calculation-service.service';

describe('CalculationServiceService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [CalculationServiceService]
    });
  });

  it('should be created', inject([CalculationServiceService], (service: CalculationServiceService) => {
    expect(service).toBeTruthy();
  }));
});
