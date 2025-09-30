import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ProductService } from '../../core/services/product.service';
import { Product } from '../../core/models/product.model';

@Component({
  selector: 'app-product',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {
  products: Product[] = [];
  isModalOpen = false;
  isDeleteModalOpen = false;
  isConnected = false; 
  currentProduct: Product = this.getEmptyProduct();
  productToDelete: Product | null = null;

  constructor(private productService: ProductService) { }

  ngOnInit(): void {
  }

  connect(): void {
    this.isConnected = true;
    this.loadProducts();
  }

  getEmptyProduct(): Product {
    return { id: 0, name: '', description: '', value: 0 };
  }

  loadProducts(): void {
    this.productService.getProducts().subscribe(data => {
      this.products = data;
    });
  }

  openModal(): void {
    this.currentProduct = this.getEmptyProduct();
    this.isModalOpen = true;
  }

  closeModal(): void {
    this.isModalOpen = false;
  }

  editProduct(product: Product): void {
    this.currentProduct = { ...product };
    this.isModalOpen = true;
  }

  saveProduct(): void {
    if (this.currentProduct.id) { // atualiza produto existente
      this.productService.updateProduct(this.currentProduct).subscribe(() => {
        this.loadProducts();
        this.closeModal();
      });
    } else { // adiciona novo produto
      // remove 'id' e 'lastUpdatedOn' antes de requisitar
      const { id, lastUpdatedOn, ...newProduct } = this.currentProduct;
      this.productService.addProduct(newProduct).subscribe(() => {
        this.loadProducts();
        this.closeModal();
      });
    }
  }

  openDeleteModal(product: Product): void {
    this.productToDelete = product;
    this.isDeleteModalOpen = true;
  }

  closeDeleteModal(): void {
    this.isDeleteModalOpen = false;
    this.productToDelete = null;
  }

  confirmDelete(): void {
    if (this.productToDelete) {
      this.productService.deleteProduct(this.productToDelete.id).subscribe(() => {
        this.loadProducts();
        this.closeDeleteModal();
      });
    }
  }
}