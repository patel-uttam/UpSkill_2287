import { NgModule } from '@angular/core';
import { PreloadAllModules, RouterModule, Routes } from '@angular/router';
import { DepartmentComponent } from './admin/department/department.component';
import { DeptJobTitleComponent } from './admin/dept-job-title/dept-job-title.component';
import { GlobalErrorComponent } from './global-error/global-error.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { NotFoundComponent } from './not-found/not-found.component';
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
  {path:'Login',component:LoginComponent,data:{AnimationTrigger:"login"}},
  {path:'error',component:GlobalErrorComponent},
  {path:'**',pathMatch:'full',component:NotFoundComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
