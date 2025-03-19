import { Injectable, NgZone } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Product } from '../model/product';
import { ReturnStatement } from '@angular/compiler';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  readonly apiproduct = 'https://localhost:7191/api/Products/';
  readonly apicategory = 'https://localhost:7191/api/Category/';
  constructor(private http: HttpClient) { }
  //-------------------PRODUCT------------------------------------------------------------------------------
  GetAllProduct(pageNumber: number, pageSize: number): Observable<Product>{
    return this.http.get<Product>(this.apiproduct + `GetAll?pagenumber=${pageNumber}&pagesize=${pageSize}`);
  }
  GetProductById(id: any): Observable<any[]>{
    return this.http.get<any>(this.apiproduct + "GetProductById/" + id)
  }
  //Get product by category 
  GetAllProductCategory(id: number, pageNumber: number, pageSize: number): Observable<Product>{
    return this.http.get<Product>(this.apiproduct + `GetProductByCategory/${id}?pagenumber=${pageNumber}&pagesize=${pageSize}`);
  }
  //Get product mới nhất 
  GetProductNewCreated(pageNumber: number, pageSize: number): Observable<Product>{
    return this.http.get<Product>(this.apiproduct + `GetProductCreatedAt?pagenumber=${pageNumber}&pagesize=${pageSize}`);
  }
  //Get product cũ nhất
  GetProductCreated(pageNumber: number, pageSize: number): Observable<Product>{
    return this.http.get<Product>(this.apiproduct + `GetProductCreated?pagenumber=${pageNumber}&pagesize=${pageSize}`);
  }
  //Get product tăng dần 
  GetProductASCPrice(pageNumber: number, pageSize: number): Observable<Product>{
    return this.http.get<Product>(this.apiproduct + `GetProductASCPrice?pagenumber=${pageNumber}&pagesize=${pageSize}`);
  }
  //Get product giảm dần 
  GetProductDESCPrice(pageNumber: number, pageSize: number): Observable<Product>{
    return this.http.get<Product>(this.apiproduct + `GetProductDESCPrice?pagenumber=${pageNumber}&pagesize=${pageSize}`);
  }
  //Get color
  GetColor(): Observable<any[]>{
    return this.http.get<any>(this.apiproduct + 'GetColor');
  }
  //Get size
  GetSize(): Observable<any[]>{
    return this.http.get<any>(this.apiproduct + 'GetSize');
  }
  //-----------------CATEGORY-------------------------------------------------------------------------------
  GetCategory(): Observable<any[]>{
    return this.http.get<any>(this.apicategory + 'GetAll');
  }
}

