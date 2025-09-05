import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator, MatPaginatorModule, PageEvent } from '@angular/material/paginator';
import { MatSort, MatSortModule, Sort } from '@angular/material/sort';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatButtonModule } from '@angular/material/button';
import { CommonModule } from '@angular/common';
import { CustomerPrediction, Order } from '../interfaces/order-management.interfaces';
import { OrderManagementService } from '../services/order-management.service';
import { OrdersModalComponent } from '../modals/orders-modal.component';
import { debounceTime, Subject } from 'rxjs';
import { FormsModule } from '@angular/forms';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { NewOrderModalComponent } from '../modals/new-order-modal.component';

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.css'],
  standalone: true,
  imports: [
    CommonModule,
    MatTableModule,
    FormsModule,
    MatPaginatorModule,
    MatSortModule,
    MatInputModule,
    MatFormFieldModule,
    MatButtonModule,
    MatToolbarModule,
    MatDialogModule,
    MatIconModule
  ]
})
export class OrderComponent implements OnInit {
  displayedColumns = ['orderId', 'orderDate', 'shippedDate'];
  dataSource = new MatTableDataSource<Order>([]);
  totalItems = 0;
  pageSize = 10;
  pageIndex = 0;
  sortField = 'orderId';
  sortOrder: 'asc' | 'desc' = 'asc';
  filterValue = '';
  private filterSubject = new Subject<string>();

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(private service: OrderManagementService, private dialog: MatDialog) {
  }

  ngAfterViewInit() {
  this.dataSource.paginator = this.paginator;
  this.dataSource.sort = this.sort;
  }

  ngOnInit() {
    this.loadData();
    this.filterSubject.pipe(debounceTime(300)).subscribe(value => {
      this.filterValue = value;
      this.pageIndex = 0;
      this.loadData();
    });
  }

  loadData() {
    this.service.getAllOrders(this.pageIndex + 1, this.pageSize, this.sortField, this.sortOrder, this.filterValue)
      .subscribe(res => {
        console.log('Respuesta completa del backend:', res);
        this.dataSource.data = res;
        this.totalItems = res.length;
        console.log('Datos recibidos:', this.dataSource.data);
      });
  }

  onPageChange(event: PageEvent) {
    this.pageIndex = event.pageIndex;
    this.pageSize = event.pageSize;
    this.loadData();
  }

  onSortChange(sort: Sort) {
    this.sortField = sort.active;
    this.sortOrder = sort.direction === '' ? 'asc' : sort.direction;
    this.loadData();
  }

  onFilterChange(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value.trim().toLowerCase();
    this.filterSubject.next(filterValue);
  }

  openOrdersModal(customer: CustomerPrediction) {
    this.dialog.open(OrdersModalComponent, {
      width: '800px',
      data: { 
        customerName: customer.customerName,
        custId: customer.custId


       }
    });
  }

  openNewOrderModal(customer: CustomerPrediction) {
    const dialogRef = this.dialog.open(NewOrderModalComponent, {
      width: '800px',
      data: { 
        customerName: customer.customerName,
        custId: customer.custId
      }
    });

    dialogRef.afterClosed().subscribe(result => {
      if(result === true){
        this.loadData();
      }
    });
  }
}
