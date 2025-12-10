import { Component, OnInit } from '@angular/core';
import { Product } from '../../../models/product.model';
import { ProductService } from '../../../services/product.service'
import { Router } from '@angular/router';
import { CurrencyPipe, NgIf, NgFor } from '@angular/common';


@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css'],
  standalone: true,
  imports: [NgIf, NgFor, CurrencyPipe]
})
export class ProductListComponent implements OnInit {

  products: Product[] = [];
  isLoading = false;
  errorMessage = '';

  constructor(
    private productService: ProductService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.loadProducts();
  }

  loadProducts(): void {
    this.isLoading = true;
    this.errorMessage = '';
    this.productService.getAll().subscribe({
      next: (products) => {
        this.products = products;
        this.isLoading = false;
      },
      error: () => {
        this.errorMessage = 'Erro ao carregar os produtos.';
        this.isLoading = false;
      }
    });
  }

  onCreate(): void {
    this.router.navigate(['/products/new']);
  }

  onEdit(product: Product): void {
    if (!product.id) return;
    this.router.navigate(['/products', product.id, 'edit']);
  }

  onDelete(product: Product): void {
    if (!product.id) return;
    const confirmDelete = confirm(`Deseja realmente excluir o produto "${product.name}"?`);
    if (!confirmDelete) return;

    this.productService.delete(product.id).subscribe({
      next: () => {
        this.loadProducts();
      },
      error: () => {
        this.errorMessage = 'Erro ao excluir o produto.';
      }
    });
  }
}
