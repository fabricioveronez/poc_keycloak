import { Component, OnInit } from '@angular/core';
import { Produto } from '../produto.models';
import { ProdutoService } from '../produto.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-produto-editar',
  templateUrl: './produto-editar.component.html',
  styleUrls: ['./produto-editar.component.css']
})
export class ProdutoEditarComponent implements OnInit {

  title = 'front';
  produto: Produto = new Produto();

  constructor(private service: ProdutoService,
    private route: ActivatedRoute) {

  }

  public async ngOnInit(): Promise<any> {

    this.route.paramMap.subscribe(async paramMap => {

      try {
        if (paramMap.get('id')) {
          this.produto = await this.service.obterPorId(paramMap.get('id'));
        }
      } catch (error) {
        alert('Erro ao carregar.');
      }
    });
  }

  public async salvar(ev: Event): Promise<any> {

    try {
      if (!this.produto.id) {
        await this.service.inserir(this.produto);
      } else {
        await this.service.salvar(this.produto.id, this.produto);
      }
    } catch (error) {
      alert('Erro ao cadastrar.');
    }
  }
}
