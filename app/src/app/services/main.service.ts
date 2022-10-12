import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MainService {
	public APIEndpoint = `${environment.APIEndpoint}/`;
	public APIServer = environment.APIServer;
  public Images = {
    loading:"../../../assets/images/loading.gif"
  };
  constructor(private http: HttpClient) { }

  public getHeader(){
    let headers: HttpHeaders = new HttpHeaders();
    let params: HttpParams = new HttpParams();
    return {"headers":headers, "params":params};
  }

  public get(route:any): Observable<any> {
    return this.http.get(this.APIEndpoint + route,this.getHeader());
  }
}
