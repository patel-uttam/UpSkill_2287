import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuardGuard } from '../Services/auth-guard.guard';
import { DepartmentResolverService } from '../Services/department-resolver.service';
import { AdminHomeComponent } from './admin-home/admin-home.component';
import { AdminComponent } from './admin/admin.component';
import { DepartmentComponent } from './department/department.component';
import { DeptJobTitleComponent } from './dept-job-title/dept-job-title.component';
import { EmployeeComponent } from './employee/employee.component';

const routes: Routes = [
  {path:'',component:AdminComponent,children:
    [
      {path:'Admin',component:AdminHomeComponent,canActivate:[AuthGuardGuard]},
      {path:'Admin/Employee',component:EmployeeComponent,data:{AnimationTrigger:"AdminEmployee"},canActivate:[AuthGuardGuard]},
      {path:'Admin/Department',component:DepartmentComponent,resolve:{department:DepartmentResolverService},data:{AnimationTrigger:"AdminDepartment"},canActivate:[AuthGuardGuard],canActivateChild:[AuthGuardGuard],children:
        [
          {path:'Employees/:id',component:DeptJobTitleComponent,}
        ]}
    ]
  }
  ,
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
