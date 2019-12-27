import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ProdutoService } from '../produto.service';
import { Produto } from '../produto.models';

@Component({
  selector: 'app-produto-lista',
  templateUrl: './produto-lista.component.html',
  styleUrls: ['./produto-lista.component.css']
})
export class ProdutoListaComponent implements OnInit {

  lista: Produto[] = [];

  constructor(private service: ProdutoService,
    private route: ActivatedRoute) { }

  async ngOnInit() {

    this.lista = await this.service.obter();
  }

}
