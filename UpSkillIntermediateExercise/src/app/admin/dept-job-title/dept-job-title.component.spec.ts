import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeptJobTitleComponent } from './dept-job-title.component';

describe('DeptJobTitleComponent', () => {
  let component: DeptJobTitleComponent;
  let fixture: ComponentFixture<DeptJobTitleComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DeptJobTitleComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DeptJobTitleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
