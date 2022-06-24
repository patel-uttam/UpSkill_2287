import { TestBed } from '@angular/core/testing';

import { DeptEmpHistoryResolverService } from './dept-emp-history-resolver.service';

describe('DeptEmpHistoryResolverService', () => {
  let service: DeptEmpHistoryResolverService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DeptEmpHistoryResolverService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
