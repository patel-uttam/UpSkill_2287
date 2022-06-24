import { NgModule } from '@angular/core';
import { PreloadAllModules, RouterModule, Routes } from '@angular/router';
import { DepartmentComponent } from './admin/department/department.component';
import { DeptJobTitleComponent } from './admin/dept-job-title/dept-job-title.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { ProfileComponent } from './profile/profile.component';
import { DepartmentResolverService } from './Services/department-resolver.service';

const routes: Routes = [
  {path:'',component:HomeComponent},
  {path:'Profile',component:ProfileComponent,canLoad:[]},
  {path:'Admin/Employee' ,loadChildren:()=> import('src/app/admin/admin.module').then(a=>a.AdminModule)},
  {path:'Admin/Department',component:DepartmentComponent,resolve:{department:DepartmentResolverService},data:{AnimationTrigger:"AdminDepartment"},children:
  [
    {path:'Employees/:id',component:DeptJobTitleComponent,}
  ]},
  {path:'Login',component:LoginComponent,data:{AnimationTrigger:"login"}}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
