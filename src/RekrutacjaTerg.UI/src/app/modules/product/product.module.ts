import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ProductRoutingModule } from './product-routing.module';
import { ProductListComponent } from './components/product-list/product-list.component';
import { ButtonComponent } from "../core/ui/button/button.component";
import { ProductAddComponent } from './components/product-add/product-add.component';
import { TableComponent } from "../core/ui/table/table.component";
import { MatButtonModule } from '@angular/material/button';
import { ReactiveFormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';


@NgModule({
    declarations: [
        ProductListComponent,
        ProductAddComponent
    ],
    imports: [
        CommonModule,
        ProductRoutingModule,
        ButtonComponent,
        TableComponent,
        MatButtonModule,
        ReactiveFormsModule,
        MatFormFieldModule,
        MatInputModule
    ]
})
export class ProductModule { }
