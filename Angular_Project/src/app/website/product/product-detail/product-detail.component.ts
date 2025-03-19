import { Component, OnInit } from '@angular/core';
import { ApiService } from '../../API/api.service';
import { CommonModule } from '@angular/common';
import { ActivatedRoute } from '@angular/router';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-product-detail',
  imports: [CommonModule, FormsModule],
  templateUrl: './product-detail.component.html',
  styleUrl: './product-detail.component.css'
})
export class ProductDetailComponent implements OnInit{
  id: any;
  product: any [] = [];
  color: any [] = [];
  size: any [] = [];
  constructor( private api: ApiService, private router: ActivatedRoute){}
  ngOnInit(): void {
    this.id = this.router.snapshot.params['id'];
    this.GetProductById(this.id);
    this.GetColor();
    this.GetSize();
  }

  GetProductById(id: any){
    this.api.GetProductById(id).subscribe(data =>{
      this.product = data;
      console.log('product:',data);
    })
  }
  //get color
  GetColor(){
    this.api.GetColor().subscribe(data =>{
      this.color = data;
      console.log('color:',data);
    });
  }
  //get size 
  GetSize(){
    this.api.GetSize().subscribe(data =>{
      this.size = data;
      console.log('size:',data);
    });
  }
}
