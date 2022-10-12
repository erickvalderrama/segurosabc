import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-button',
  templateUrl: './button.component.html',
  styleUrls: ['./button.component.scss']
})
export class ButtonComponent implements OnInit {
  @Input() class:any='';
  @Input() text:any='';
  @Input() type:any="button";
  @Input() icon:any='';
  @Input() disabled:boolean=false;
  constructor() { }

  ngOnInit() {
  }

}
