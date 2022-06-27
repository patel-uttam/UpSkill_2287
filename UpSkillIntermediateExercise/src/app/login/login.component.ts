import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Login } from '../Models/Login';
import { LoginService } from '../Services/login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private loginService:LoginService,private toast:ToastrService,private router:Router ) { }

  ngOnInit(): void {
    var local = localStorage.getItem("login");
    if(local=="true")
    {
      this.router.navigate(['']);
    }
  }

  login:Login={
    userName: '',
    password: ''
  };
  Login(form:NgForm)
  {
    var data = form.value;
    this.login.userName=data.username;
    this.login.password=data.pass;
    console.log(this.login);
    this.loginService.Login(this.login).subscribe
    (
      (res:any)=>{
        if(res)
        {
          this.toast.success("login successfull");
          localStorage.setItem("login","true");
          this.router.navigate(['Home']);
        }
      },
      (error:any)=>{
        if(error["status"]==401)
        {
          this.toast.error("user not valid");
        }
      }
    )
  }
}
