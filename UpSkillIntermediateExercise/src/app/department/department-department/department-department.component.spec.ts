import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DepartmentDepartmentComponent } from './department-department.component';

describe('DepartmentDepartmentComponent', () => {
  let component: DepartmentDepartmentComponent;
  let fixture: ComponentFixture<DepartmentDepartmentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DepartmentDepartmentComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DepartmentDepartmentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
