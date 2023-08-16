import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {

  public imageEnabled: boolean = false;
  public eventos: any = [];
  public eventosFiltrados: any = [];
  private _filtroBusca: string = '';

  public get filtroLista():string{
    return this._filtroBusca;
  }

  public set filtroLista(value:string){
    this._filtroBusca = value;

    this.eventosFiltrados = this.filtroLista ? this.filtrarEventos(this.filtroLista) : this.eventos;
  }

   filtrarEventos(filtro: string): any{
    filtro = filtro.toLocaleLowerCase();
    return this.eventos.filter(
      (evento: {tema:string, local:string}) => evento.tema.toLocaleLowerCase().indexOf(filtro) !== -1 || evento.local.toLocaleLowerCase().indexOf(filtro) !== -1
    );
  }

  constructor(private http: HttpClient) {

   }

  ngOnInit(): void {
    this.getEventos()
  }

  public getEventos(){
    this.http.get("https://localhost:5001/api/Evento").subscribe(
      response => {
        this.eventos = response;
        this.eventosFiltrados = this.eventos;
      },
      error => console.log(error)
    );
  }


  public enabledButton(): void{
    this.imageEnabled = !this.imageEnabled;
  }


}
