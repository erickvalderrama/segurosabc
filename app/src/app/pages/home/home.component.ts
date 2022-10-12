import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { ClientPayment } from 'src/app/dto/client-payment';
import { MainService } from 'src/app/services/main.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  public data:Array<ClientPayment> = new Array<ClientPayment>();
  public paymentsDetail:Array<ClientPayment> = new Array<ClientPayment>();
  public currentUser:string = "";
  constructor(public mainService: MainService, private toastr: ToastrService) { }

  ngOnInit(): void {
  }

  result(r:Array<ClientPayment>){
    this.data = r;
  }

  showDetails(d:ClientPayment){
    this.currentUser = d.identification;
    this.paymentsDetail = [];
    for(let i=1; i<5;i++){
      let n = new ClientPayment();
      n.amount = 100*i;
      n.date = new Date().toString();
      this.paymentsDetail.push(n)
    }
    console.log(this.paymentsDetail);
  }
  
}
