import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { CreateProductCommand } from 'src/app/modules/core/models/requests/create-product-command';
import { ProductService } from 'src/app/modules/core/services/product.service';

@Component({
  selector: 'app-product-add',
  templateUrl: './product-add.component.html',
  styleUrls: ['./product-add.component.css']
})

export class ProductAddComponent implements OnInit {
  productForm!: FormGroup<ProductForm>;

  constructor(private router: Router,
    private fb: FormBuilder,
    private productService: ProductService) {}

  ngOnInit(): void {
    this.productForm  = this.fb.group<ProductForm>({
      code: this.fb.control<string>('', Validators.required),
      name: this.fb.control<string>('', Validators.required),
      price: this.fb.control<number>(0, [Validators.required, Validators.min(1)]),
    });
  }

  submit(): void {
    if(this.productForm.valid) {
      const request: CreateProductCommand = {
        name: this.productForm.value.name!,
        code: this.productForm.value.code!,
        price: this.productForm.value.price!
      }
      this.productService.add(request).subscribe(() => {
        this.router.navigate(['..']);
      });
    }
  }
}

interface ProductForm {
  code: FormControl<string | null>,
  name: FormControl<string | null>,
  price: FormControl<number | null>
}
