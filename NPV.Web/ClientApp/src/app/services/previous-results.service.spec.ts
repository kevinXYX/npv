import { TestBed, inject } from '@angular/core/testing';

import { PreviousResultsService } from './previous-results.service';

describe('PreviousResultsService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [PreviousResultsService]
    });
  });

  it('should be created', inject([PreviousResultsService], (service: PreviousResultsService) => {
    expect(service).toBeTruthy();
  }));
});
