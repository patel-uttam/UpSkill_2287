import { TestBed } from '@angular/core/testing';

import { DeactiveGuardGuard } from './deactive-guard.guard';

describe('DeactiveGuardGuard', () => {
  let guard: DeactiveGuardGuard;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    guard = TestBed.inject(DeactiveGuardGuard);
  });

  it('should be created', () => {
    expect(guard).toBeTruthy();
  });
});
