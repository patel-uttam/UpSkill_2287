import { ErrorHandler, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule,HTTP_INTERCEPTORS } from '@angular/common/http'
import { FormsModule } from '@angular/forms';
import { ToastrModule } from 'ngx-toastr';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

// components and service
import { EmployeeServiceService } from './Services/employee-service.service';
import  { DepartmentServiceService } from './Services/department-service.service';
import { HomeComponent } from './home/home.component';
import { ProfileComponent } from './profile/profile.component'
import { AdminModule } from './admin/admin.module';
import { AdminRoutingModule } from './admin/admin-routing.module';
import { LoginComponent } from './login/login.component';
import  { GlobalHandlerServiceService } from './Services/global-handler-service.service';
import  { InterceptorService } from './Services/interceptor.service';
import { GlobalErrorComponent } from './global-error/global-error.component';
import { NotFoundComponent } from './not-found/not-found.component';
import { EmployeeModule } from './employee/employee.module';
import { EmployeeRoutingModule } from './employee/employee-routing.module';
import { DepartmentModule } from './department/department.module';
import { DepartmentRoutingModule } from './department/department-routing.module';


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    ProfileComponent,
    LoginComponent,
    GlobalErrorComponent,
    NotFoundComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
    EmployeeModule,
    EmployeeRoutingModule,
    DepartmentModule,
    DepartmentRoutingModule,
    AdminModule,
    AdminRoutingModule,
    AppRoutingModule,
  ],
  providers: [EmployeeServiceService,DepartmentServiceService,{provide:ErrorHandler,useClass:GlobalHandlerServiceService},{provide:HTTP_INTERCEPTORS,useClass:InterceptorService,multi:true}],
  bootstrap: [AppComponent]
})
export class AppModule { }
