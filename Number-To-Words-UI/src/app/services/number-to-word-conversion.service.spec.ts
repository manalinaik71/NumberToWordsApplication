import { TestBed } from '@angular/core/testing';

import { NumberToWordConversionService } from './number-to-word-conversion.service';

describe('NumberToWordConversionService', () => {
  let service: NumberToWordConversionService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(NumberToWordConversionService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
