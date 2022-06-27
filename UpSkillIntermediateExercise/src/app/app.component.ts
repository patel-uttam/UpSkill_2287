import { animate, animateChild, group, query, style, transition, trigger } from '@angular/animations';
import { Component, OnInit, ViewChild } from '@angular/core';
import { ChildrenOutletContexts } from '@angular/router';
import { slideAnimation } from './SlideAnimation';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  animations:[slideAnimation],
  
})
export class AppComponent {
  title = 'UpSkillIntermediateExercise';

  constructor(private route : ChildrenOutletContexts)
  {}

  GetTrasition()
  {
    // console.log(this.route.getContext('primary')?.route?.snapshot.data?.['AnimationTrigger']);
    return this.route.getContext('primary')?.route?.snapshot.data?.['AnimationTrigger'];
  }

  selecteddate="";
  datetype = typeof(this.selecteddate);
  // @ViewChild() date : HTMLInputElement
}
