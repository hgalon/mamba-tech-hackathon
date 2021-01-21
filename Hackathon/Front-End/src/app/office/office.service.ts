import { Cargo } from '../model/cargo.model';
import { Area } from '../model/area.model';
import { Carreira } from '../model/carreira.model';
import { Trilha } from '../model/trilha.model';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class OfficeService {

  private url = 'https://totvs-hackathon.azurewebsites.net/api/trilha'

  cargo:Cargo = { titulo : "Analise de desenvolvimento I", area : "Dev Team", nivel:1 }
  cargo2:Cargo = { titulo : "Analise de desenvolvimento II", area : "Dev Team", nivel:2 }

  _areas:Area[] = [{ titulo : "Desenvolvimento e Frame", cargos : [this.cargo,this.cargo2]}]

  _carreiras:Carreira[] = [{ titulo : "Desenvolvimento e Frame", areas:this._areas }]

  trilha:Trilha[] = 
  [{
     titulo:"Tech",
     carreiras:this._carreiras
  },
  {
    titulo:"CST",
    carreiras:this._carreiras
  }
]

  constructor(private httpCli:HttpClient) { 

  }

  getAll(): Observable<Array<any>> {
    return this.httpCli.get(this.url) as Observable<Array<any>>;
  }
}
