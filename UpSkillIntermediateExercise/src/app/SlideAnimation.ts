import { trigger , animation , state , transition, style, query, group, animateChild, animate } from '@angular/animations';


export const slideAnimation = trigger(
    'Animation',[
        transition('* => login',[

            query(':enter, :leave',[style({position:'absolute', top:'0%', right:'50%', width:'100%',fontSize:'25px'})],{optional:true}),
            query(':enter',[style({right:'-100%',top:'50%'})],{optional:true}),
            query(':leave',animateChild(),{optional:true}),
            group([
                query(':leave',[animate('300ms ease-out',style({top:'0%' ,opacity:'0.1'}))],{optional:true}),
                query(':enter',[animate('1000ms ease-in',style({right:'0%'}))],{optional:true})
            ])
        ])
    ]
)