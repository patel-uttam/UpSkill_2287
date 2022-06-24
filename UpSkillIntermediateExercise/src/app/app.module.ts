import { NgModule } from '@angular/core';
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


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    ProfileComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
    AdminModule,
    AdminRoutingModule,
    AppRoutingModule,
  ],
  providers: [EmployeeServiceService,DepartmentServiceService],
  bootstrap: [AppComponent]
})
export class AppModule { }
