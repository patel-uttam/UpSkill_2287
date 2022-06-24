import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { EmployeeServiceService } from '../../Services/employee-service.service';
import { filter, map, Observable, tap } from 'rxjs';
import { Employee } from '../../Models/Employee';
import { Paging } from '../../Models/paging';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent implements OnInit {

  constructor(private employeeService : EmployeeServiceService , private route:ActivatedRoute) { }

  ngOnInit(): void {
    this.employeeService.GetEmployees(this.queryParam).pipe
    (
      tap ((res:any)=>{
        this.isPrevious = res.isprevious;
        this.isNext = res.isnext;
        this.distinctjobTitle = res.jobTitle;
        this.distinctOrganizationLevel = res.organizationLevel;
        res.data.filter((elm:Employee,i:number,arr:Employee[])=>{
              if(!this.distinctjobTitle.includes(elm.jobTitle as string))
              {
                this.distinctjobTitle.push(elm.jobTitle as string);
              }
              if(!this.distinctOrganizationLevel.includes(elm.organizationLevel as number))
              {
                this.distinctOrganizationLevel.push(elm.organizationLevel as number);
              }
            })
      })
    )
    .subscribe
    (
      (response: any) => 
      {
        for(let R of response.data as Employee[])
        {
          this.employees.push(R as Employee);
        }
      }
    )
    console.log("JobTitle" , this.distinctjobTitle);
    console.log("organizationlevel" , this.distinctOrganizationLevel)
  }

  // variables and declarations

    employees:Employee[]=[];
    pageNumber=1;
    // itemperpage:number=25;
    isNext:boolean = true
    isPrevious:boolean = true
    distinctOrganizationLevel:number[] = [];
    distinctjobTitle:string[]=[];

    // queryparam object
    queryParam:Paging={
      jobTitle: [],
      organizationLevel: '',
      startVacation: '',
      endVacation: '',
      startSickleave: '',
      endSickleave: '',
      pageNumber: 1,
      itemPerPage: 15
    }

    //filter variable
    filterJob:string[]=[];
    filterOrganization:number=2;
  //


  // Methods

  previous()
  {
    this.employees = [];
    this.pageNumber--;

    this.queryParam.pageNumber=this.pageNumber;
    // this.queryParam.jobTitle = this.filterJob;
    // this.queryParam.organizationLevel = this.filterOrganization.toString();

    this.employeeService.GetEmployees(this.queryParam).subscribe
    (
      (response: any) => 
      {
        for(let R of response.data as [])
        {
          this.employees.push(R);
        }

        this.isNext = response.isnext;
        this.isPrevious = response.isprevious;

      }
    )
  }

  next()
  {
    this.employees = [];
    this.pageNumber++;

    this.queryParam.pageNumber=this.pageNumber;

    this.employeeService.GetEmployees(this.queryParam).subscribe
    (
      (response: any) => 
      {
        for(let R of response.data as [])
        {
          this.employees.push(R);
        }

        this.isNext = response.isnext;
        this.isPrevious = response.isprevious;

      }
    )
  }

  filterJobTitle(e:Event)
  {

    let isChecked = (e.target as HTMLInputElement).checked;
    let value = (e.target as HTMLInputElement).value;
    console.log(value);
    if(isChecked)
    {
      this.filterJob.push(value);

    }
    else if(!isChecked)
    {
      if(this.filterJob.includes(value))
      {
        this.filterJob.splice(this.filterJob.indexOf(value),1);
      }
    }
    console.log(this.filterJob);
  }

  ApplyFilter()
  {
    this.employees = [];

    this.queryParam.pageNumber=1
    this.queryParam.jobTitle = this.filterJob;
    this.queryParam.organizationLevel = this.filterOrganization.toString();

    this.employeeService.GetEmployees(this.queryParam).subscribe
    (
      (response: any) => 
      {
        for(let R of response.data as [])
        {
          this.employees.push(R);
        }

        this.isNext = response.isnext;
        this.isPrevious = response.isprevious;

      }
    )
  }
  
}
