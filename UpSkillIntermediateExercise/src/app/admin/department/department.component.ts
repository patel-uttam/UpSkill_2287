import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { map } from 'rxjs';
import { Department } from 'src/app/Models/Department';
@Component({
  selector: 'app-department',
  templateUrl: './department.component.html',
  styleUrls: ['./department.component.css']
})
export class DepartmentComponent implements OnInit {

  constructor(private activeroute:ActivatedRoute, private tstr:ToastrService) {

   }

   Departmentdata:Department[]=[]

   deptGroup:string[] = [];

  ngOnInit(): void {
    this.Departmentdata = this.activeroute.snapshot.data['department'] as Department[];

    console.log("department" , this.Departmentdata);

    var filterdata = this.Departmentdata.filter((elem:Department,i,arr:Department[])=>{
        if(!this.deptGroup.includes(elem.groupName))
        {
          this.deptGroup.push(elem.groupName);
        }
        else
        {
          console.log(!this.deptGroup.includes(elem.groupName));
        }
    })

    console.log(this.deptGroup);
  }

}
