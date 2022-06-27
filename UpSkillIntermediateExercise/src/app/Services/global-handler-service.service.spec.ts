import { TestBed } from '@angular/core/testing';

import { GlobalHandlerServiceService } from './global-handler-service.service';

describe('GlobalHandlerServiceService', () => {
  let service: GlobalHandlerServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(GlobalHandlerServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
