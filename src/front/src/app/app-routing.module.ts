import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ProdutoEditarComponent } from './produto/produto-editar/produto-editar.component';
import { ProdutoListaComponent } from './produto/produto-lista/produto-lista.component';
import { AppAuthGuard } from './utils/app-auth-guard';



const routes: Routes = [
    { path: 'editar/:id', component: ProdutoEditarComponent, canActivate: [AppAuthGuard] },
    { path: 'editar', component: ProdutoEditarComponent },
    // { path: 'editar', component: ProdutoEditarComponent, canActivate: [AppAuthGuard] },
    { path: 'listar', component: ProdutoListaComponent },
    { path: '', redirectTo: '/listar', pathMatch: 'full' }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }