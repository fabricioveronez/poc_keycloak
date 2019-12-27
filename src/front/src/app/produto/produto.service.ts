import { HttpClient } from '@angular/common/http';
import { Produto } from './produto.models';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
    providedIn: 'root',
})
export class ProdutoService {

    constructor(private http: HttpClient) {

    }

    public inserir(produto: Produto): Promise<any> {
        return this.http.post(`${environment.apiURL}/produto`, produto).toPromise();
    }

    public salvar(id: string, produto: Produto): Promise<any> {
        return this.http.put(`${environment.apiURL}/produto/${id}`, produto).toPromise();
    }

    public excluir(id: string): Promise<any> {
        return this.http.delete(`${environment.apiURL}/produto/${id}`).toPromise();
    }

    public obterPorId(id: string): Promise<Produto> {
        return this.http.get<Produto>(`${environment.apiURL}/produto/${id}`).toPromise();
    }

    public obter(): Promise<Produto[]> {
        return this.http.get<Produto[]>(`${environment.apiURL}/produto`).toPromise();
    }
}