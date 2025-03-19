import { Component, OnInit } from '@angular/core';
import { ApiService } from '../API/api.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { RouterLink } from '@angular/router';
@Component({
  selector: 'app-product',
  imports: [CommonModule, FormsModule, RouterLink],
  templateUrl: './product.component.html',
  styleUrl: './product.component.css'
})
export class ProductComponent implements OnInit{
  ListProduct: any [] = [];
  ListCategory: any [] = [];
  pageNumber: number = 1;
  pageSize: number = 24;
  totalPages: number = 0;
  selectSort: any; 
  constructor(private api: ApiService){}
  ngOnInit(): void {
    this.GetAllProduct();
    this.GetAllCategory();
  }

  GetAllProduct(){
    this.api.GetAllProduct(this.pageNumber, this.pageSize).subscribe(response => {
      this.ListProduct = response.Data;
      this.totalPages = response.TotalPages;
      console.log(response);
    });
  }

  GetAllCategory(){
    this.api.GetCategory().subscribe(data =>{
      this.ListCategory = data;
      console.log(data);
    })
  }

  GetProductByCategory(id: number){
    this.pageNumber = 1; // Reset về trang đầu khi chọn danh mục mới
    this.api.GetAllProductCategory(id, this.pageNumber, this.pageSize).subscribe(response => {
    this.ListProduct = response.Data;
    this.totalPages = response.TotalPages;
    console.log(response);
    });
  }

  SortProduct(){
    if(this.selectSort == '1'){
      this.GetAllProduct();
    }
    else if(this.selectSort == '2'){
      this.api.GetProductNewCreated(this.pageNumber, this.pageSize).subscribe( response=> {
        this.ListProduct = response.Data;
        this.totalPages = response.TotalPages;
        console.log(response);
      });
    }
    else if(this.selectSort == '3'){
      this.api.GetProductCreated(this.pageNumber, this.pageSize).subscribe(data => {
        this.ListProduct = data.Data;
        this.totalPages = data.TotalPages;
        console.log(data);
      });
    }
    else if(this.selectSort == '4'){
      this.api.GetProductASCPrice(this.pageNumber, this.pageSize).subscribe(data => {
        this.ListProduct = data.Data;
        this.totalPages = data.TotalPages;
        console.log(data);
      });
    }
    else if(this.selectSort == '5'){
      this.api.GetProductDESCPrice(this.pageNumber, this.pageSize).subscribe(data => {
        this.ListProduct = data.Data;
        this.totalPages = data.TotalPages;
        console.log(data);
      });
    }
  }

  showNewProducts = false;
  showSale = false;
  toggleCategory(category: string) {
    if (category === 'newProducts') {
        this.showNewProducts = !this.showNewProducts;
    } else if (category === 'sale') {
        this.showSale = !this.showSale;
    }
  }

  nextPage() {
    if (this.pageNumber < this.totalPages) {
      this.pageNumber++;
      this.GetAllProduct();
    }
  }

  prevPage() {
    if (this.pageNumber > 1) {
      this.pageNumber--;
      this.GetAllProduct();
    }
  }
}
