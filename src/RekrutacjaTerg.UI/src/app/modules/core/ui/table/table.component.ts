import { AfterViewInit, Component, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { CommonModule } from '@angular/common';
import {MatPaginator, MatPaginatorModule, PageEvent} from '@angular/material/paginator';
import {MatTableDataSource, MatTableModule} from '@angular/material/table';
import { Column } from './interfaces/column';



@Component({
  selector: 'app-table',
  standalone: true,
  imports: [CommonModule, MatTableModule, MatPaginatorModule],
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.css']
})
export class TableComponent implements AfterViewInit, OnInit{

  @Input() columns!: Array<Column>;
  @Input() data!: Array<any>;
  @Input() totalRows!: number;
  @Input() pageSizeOptions: number[] = [5, 10, 20];
  @Output() page = new EventEmitter<PageEvent>;
  currentPage: number = 0;
  dataSource: MatTableDataSource<any> = new MatTableDataSource<any>([]);
  displayedColumns!: Array<string>;

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  ngOnInit(): void {
    this.displayedColumns = this.columns.map((tableColumn: Column) => tableColumn.caption);
  }

  ngAfterViewInit(): void {
    this.dataSource = new MatTableDataSource(this.data);
    this.dataSource.paginator = this.paginator;
  }

  onPageChanged($event: PageEvent | undefined): void {
    this.page.emit($event);
  }
}
