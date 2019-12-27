import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ProdutoEditarComponent } from './produto/produto-editar/produto-editar.component';
import { ProdutoListaComponent } from './produto/produto-lista/produto-lista.component';



const routes: Routes = [
    { path: 'editar/:id', component: ProdutoEditarComponent },
    { path: 'editar', component: ProdutoEditarComponent },
    { path: 'listar', component: ProdutoListaComponent },
    { path: '', redirectTo: '/listar', pathMatch: 'full' }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }