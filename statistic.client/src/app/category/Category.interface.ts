export interface Category {
    id?: number | undefined;
    name?: string | undefined;
    description?: string | undefined;
    parentCategoryId?: number | undefined;
    parentCategory?: Category | undefined;
    subcategories?: Category[];
    route?: string;
  }