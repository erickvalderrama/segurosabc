import { Injectable } from '@angular/core';
import { MainService } from './main.service';

@Injectable({
  providedIn: 'root'
})
export class ClientsService {

  constructor(private mainService:MainService) { }

  public clientPayments(identification:string){
    return this.mainService.get(`clients/payments?identification=${identification}`);
  }

}
