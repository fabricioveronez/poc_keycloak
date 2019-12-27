import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProdutoListaComponent } from './produto-lista/produto-lista.component';
import { ProdutoEditarComponent } from './produto-editar/produto-editar.component';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';



@NgModule({
  declarations: [ProdutoListaComponent, ProdutoEditarComponent],
  imports: [
    CommonModule,
    FormsModule,
    RouterModule,
  ]
})
export class ProdutoModule { }
