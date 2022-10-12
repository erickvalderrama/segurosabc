import { Component, EventEmitter, OnInit, Output} from '@angular/core';
import { MainService } from 'src/app/services/main.service';
import { ClientsService } from 'src/app/services/clients.service';
import { ClientPayment } from 'src/app/dto/client-payment';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-form-search',
  templateUrl: './form-search.component.html',
  styleUrls: ['./form-search.component.scss']
})
export class FormSearchComponent implements OnInit {
  public loading = false;
  public identification:string="";
  @Output() result:EventEmitter<Array<ClientPayment>> = new EventEmitter<Array<ClientPayment>>();
  constructor(public mainService: MainService, private clientService:ClientsService, private toastr:ToastrService) { }

  ngOnInit() {
  }

  search() {
    this.loading = true;
    this.clientService.clientPayments(this.identification).subscribe((data:Array<ClientPayment>)=>{
      this.loading = false;
      this.result.emit(data);
      if (data.length){
        this.toastr.success(`Se encontraron ${data.length} registros.`, "Consulta de pagos");
      }else{
        this.toastr.warning(`No se encontraron registros relacionados.`, "Consulta de pagos");
      }
    },error=>{
      this.toastr.error("Hay un error al consultar", "Consulta de pagos");
      this.loading = false;
    });
  }
}
