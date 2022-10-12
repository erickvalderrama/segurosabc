import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-label',
  templateUrl: './label.component.html',
  styleUrls: ['./label.component.scss']
})
export class LabelComponent implements OnInit {
  @Input() text:any=null;
  @Input() class:any=null;
  @Input() value:any=null;
  constructor() { }

  ngOnInit() {
  }

}
