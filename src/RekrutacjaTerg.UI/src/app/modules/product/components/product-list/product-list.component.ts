import { Component, OnInit } from '@angular/core';
import { PageEvent } from '@angular/material/paginator';
import { ActivatedRoute, Router } from '@angular/router';
import { Product } from 'src/app/modules/core/models/product';
import { GetProductsQuery } from 'src/app/modules/core/models/requests/get-products-query';
import { PagedList } from 'src/app/modules/core/models/responses/paged-list';
import { ConfigurationService } from 'src/app/modules/core/services/configuration.service';
import { ProductService } from 'src/app/modules/core/services/product.service';
import { Column } from 'src/app/modules/core/ui/table/interfaces/column';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {

  columns: Column[] = [
    {
      caption: "Id",
      field: "id"
    },
    {
      caption: "Code",
      field: "code"
    },
    {
      caption: "Name",
      field: "name"
    },
    {
      caption: "Price",
      field: "price"
    },
  ]

  products!: PagedList<Product>;
  items!: Product[];
  pageNumber: number = 1;
  pageSize: number = 5;
  totalRows: number = 0;

  constructor(private router: Router,
    private route: ActivatedRoute,
    private productService: ProductService){ }

  ngOnInit(): void {
    this.getProducts();
  }

  handleAddProductButtonClick(): void {
    this.router.navigate(['add'], { relativeTo: this.route})
  }

  handlePageChanged(event: PageEvent): void {
    this.pageNumber = event.pageIndex + 1;
    this.pageSize = event.pageSize;
    this.getProducts();
  }

  getProducts(): void {
    const request: GetProductsQuery = {
      pageSettings: {
        pageNumber: this.pageNumber,
        pageSize: this.pageSize
      }
    };

    this.productService.get(request).subscribe(response => {
      this.products = response;
      this.items = response.items;
      this.totalRows = response.totalCount;
    });
  }
}


export interface PeriodicElement {
  name: string;
  position: number;
  weight: number;
  symbol: string;
}


