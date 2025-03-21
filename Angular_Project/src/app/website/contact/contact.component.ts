import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { RouterLink } from '@angular/router';
@Component({
  selector: 'app-contact',
  standalone: true, 
  imports: [CommonModule,FormsModule],
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.css']
})
export class ContactComponent implements OnInit {
  
  constructor() { }

  ngOnInit(): void { }

  onSubmit(form: any): void {
    console.log('Form submitted', form);
    // Add your form submission logic here
  }
}
