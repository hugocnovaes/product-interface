import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map, Observable } from 'rxjs';
import { Product } from '../models/product.model';

interface ApiResponse {
  products: Product[];
  message: string;
  success: boolean;
  statusCode: number;
}

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  private apiUrl = `https://localhost:44371/api/product`;

  constructor(private http: HttpClient) { }

  // GET: /api/product/getall
  getProducts(): Observable<Product[]> {
    return this.http.get<ApiResponse>(`${this.apiUrl}/getall`).pipe(
      // retornar products diretamente
      map(response => response.products)
    );
  }

  // GET: /api/product/getone/{id}
  getProduct(id: number): Observable<Product> {
    return this.http.get<Product>(`${this.apiUrl}/getone/${id}`);
  }

  // POST: /api/product/insert
  addProduct(product: Omit<Product, 'id' | 'lastUpdatedOn'>): Observable<Product> {
    return this.http.post<Product>(`${this.apiUrl}/insert`, product);
  }

  // PUT: /api/product/update
  updateProduct(product: Product): Observable<void> {
    const payload = { product }; // formatar para API
    return this.http.put<void>(`${this.apiUrl}/update`, payload);
  }

  // DELETE: /api/product/delete/{id}
  deleteProduct(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/delete/${id}`);
  }
}