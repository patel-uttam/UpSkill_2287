import { Component, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Employee } from 'src/app/Models/Employee';
import { EmployeeServiceService } from 'src/app/Services/employee-service.service';
import { ToastrService } from 'ngx-toastr';
import { query, style, transition, trigger } from '@angular/animations';
import { tap } from 'rxjs';
@Component({
  selector: 'app-dept-job-title',
  templateUrl: './dept-job-title.component.html',
  styleUrls: ['./dept-job-title.component.css'],
  
})
export class DeptJobTitleComponent implements OnInit ,OnChanges {

  constructor(private router:ActivatedRoute , private employeeservice:EmployeeServiceService , private tstr:ToastrService) { }
  ngOnChanges(changes: SimpleChanges): void {
    
    
  }

  ngOnInit(): void {
    this.router.params.subscribe((x)=>{this.departmentId = x['id'], console.log(x),this.GetEmployeeByDept(this.departmentId)
  });
  }

  // variables
  departmentId:number=-1;
  employees:Employee[]=[];

  // methods 

  GetEmployeeByDept(deptid:number)
  {
    this.employeeservice.GetEmployeesByDepartment(deptid).subscribe
    (
      response => {
        if(response)
        {
          this.employees=[];
          this.employees = response as Employee[];
          console.log("sub",response);
        }
        else
        {
          this.tstr.info("No Employee found!!");
        }
      },
      error => {
        if(error.message.length > 0)
        {
          this.tstr.error("Somthing is wrong , couldn't load data");
        }
      },
      () => {
        console.log("subscribing is complete")
      },
      
    );

  }
}
