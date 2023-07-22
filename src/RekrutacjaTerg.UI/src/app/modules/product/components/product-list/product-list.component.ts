import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent {
  constructor(private router: Router,
    private route: ActivatedRoute){ }

  handleAddProductButtonClick(): void {
    this.router.navigate(['add'], { relativeTo: this.route})
  }
}
