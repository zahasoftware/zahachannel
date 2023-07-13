import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-cliente',
  templateUrl: './cliente.component.html',
  styleUrls: ['./cliente.component.css']
})
export class ClienteComponent {
  clientes?: any[];

  constructor(private http: HttpClient) {}

  cargarClientes() {
    this.http.get<any[]>('/api/clientes').subscribe(data => {
      this.clientes = data;
    });
  }
}
