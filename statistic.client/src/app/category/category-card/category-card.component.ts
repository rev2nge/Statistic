import { Component, OnInit } from '@angular/core';
import { Category } from '../Category.interface';
import { CategoryService } from '../../services/category.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-category-card',
  templateUrl: './category-card.component.html',
  styleUrls: ['./category-card.component.css'],
})
export class CategoryCardComponent implements OnInit {
  categories: Category[] = [];
  category: Category | undefined;

  constructor(
    private categoryService: CategoryService,
    private activatedRoute: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.activatedRoute.queryParams.subscribe((params) => {
      const parentId = params['parentId'] ? +params['parentId'] : null;

      this.categoryService.getCategories(parentId).subscribe((response) => {
        this.categories = response;
      });
    });
  }

  loadCategories(parentId: number | null): void {
    this.categoryService
      .getCategories(parentId)
      .subscribe((data: Category[]) => {
        const enrichedCategories = data.map((category) => ({
          ...category,
          route: `/categories/${category.id}`, // Генерация пути
        }));

        if (parentId === null) {
          this.categories = enrichedCategories;
        } else {
          const parentCategory = this.findCategoryById(
            parentId,
            this.categories
          );
          if (parentCategory) {
            parentCategory.subcategories = enrichedCategories;
          } else {
            console.error(`Категория с id ${parentId} не найдена`);
          }
        }
      });
  }

  toggleSubcategories(category: Category): void {
    if (category.subcategories) {
      category.subcategories = undefined;
    } else {
      this.loadCategories(category.id || null);
    }
  }

  private findCategoryById(
    id: number,
    categories: Category[]
  ): Category | undefined {
    for (const category of categories) {
      if (category.id === id) {
        return category;
      }
      if (category.subcategories) {
        const found = this.findCategoryById(id, category.subcategories);
        if (found) {
          return found;
        }
      }
    }
    return undefined;
  }
}
