import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Product } from '../../../models/product.model';
import { ProductService } from '../../../services/product.service';
import { ActivatedRoute, Router } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-product-form',
  templateUrl: './product-form.component.html',
  styleUrls: ['./product-form.component.css'],
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule]
})
export class ProductFormComponent implements OnInit {

  productForm!: FormGroup;
  isEditMode = false;
  productId?: string;
  errorMessage = '';

  constructor(
    private formBuilder: FormBuilder,
    private productService: ProductService,
    private route: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.productForm = this.formBuilder.group({
      name: ['', [Validators.required, Validators.maxLength(150)]],
      description: ['', [Validators.maxLength(500)]],
      price: [0, [Validators.required, Validators.min(0)]]
    });

    this.route.paramMap.subscribe(params => {
      const id = params.get('id');
      if (id) {
        this.isEditMode = true;
        this.productId = id;
        this.loadProduct(id);
      }
    });
  }

  loadProduct(id: string): void {
    this.productService.getById(id).subscribe({
      next: (product) => {
        this.productForm.patchValue({
          name: product.name,
          description: product.description,
          price: product.price
        });
      },
      error: () => {
        this.errorMessage = 'Erro ao carregar o produto.';
      }
    });
  }

  onSubmit(): void {
    if (this.productForm.invalid) {
      this.productForm.markAllAsTouched();
      return;
    }

    const product: Product = this.productForm.value;

    if (this.isEditMode && this.productId) {
      this.productService.update(this.productId, product).subscribe({
        next: () => this.router.navigate(['/products']),
        error: () => this.errorMessage = 'Erro ao atualizar o produto.'
      });
    } else {
      this.productService.create(product).subscribe({
        next: () => this.router.navigate(['/products']),
        error: () => this.errorMessage = 'Erro ao criar o produto.'
      });
    }
  }

  onCancel(): void {
    this.router.navigate(['/products']);
  }

  get name() { return this.productForm.get('name'); }
  get description() { return this.productForm.get('description'); }
  get price() { return this.productForm.get('price'); }
}
