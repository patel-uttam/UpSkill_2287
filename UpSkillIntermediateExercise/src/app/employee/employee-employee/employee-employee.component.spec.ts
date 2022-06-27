import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EmployeeEmployeeComponent } from './employee-employee.component';

describe('EmployeeEmployeeComponent', () => {
  let component: EmployeeEmployeeComponent;
  let fixture: ComponentFixture<EmployeeEmployeeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EmployeeEmployeeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EmployeeEmployeeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
