import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Category } from '../Category.interface';

@Component({
  selector: 'app-category-item',
  templateUrl: './category-item.component.html',
  styleUrls: ['./category-item.component.css'],
})
export class CategoryItemComponent {
  @Input() category!: Category | undefined;
  @Output() toggle = new EventEmitter<Category>();

  toggleSubcategories(): void {
    if (this.category) {
      this.toggle.emit(this.category);
    }
  }
}
