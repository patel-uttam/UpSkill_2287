import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-department-department',
  templateUrl: './department-department.component.html',
  styleUrls: ['./department-department.component.css']
})
export class DepartmentDepartmentComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
    this.untouched=false;
  }

  untouched:boolean=true;

  canExit():boolean
  {
    let isConfirm:boolean = false;

    if(this.untouched)
    {
      return isConfirm;
    }
    else
    {
      if(confirm("Changes are unsave are want to leave ?"))
      {
        isConfirm = true;
        return isConfirm
      }
      else
      {
        return isConfirm;
      }
    }

  }
}
