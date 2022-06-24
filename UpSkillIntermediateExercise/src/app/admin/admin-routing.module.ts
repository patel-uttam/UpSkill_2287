import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DepartmentResolverService } from '../Services/department-resolver.service';
import { DepartmentComponent } from './department/department.component';
import { DeptJobTitleComponent } from './dept-job-title/dept-job-title.component';
import { EmployeeComponent } from './employee/employee.component';

const routes: Routes = [
  {path:'Admin/Employee',component:EmployeeComponent,data:{AnimationTrigger:"AdminEmployee"}},
  // {path:'Admin/Department',component:DepartmentComponent,resolve:{department:DepartmentResolverService},data:{AnimationTrigger:"AdminDepartment"},children:
  //   [
  //     {path:'Employees/:id',component:DeptJobTitleComponent,}
  //   ]},
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
