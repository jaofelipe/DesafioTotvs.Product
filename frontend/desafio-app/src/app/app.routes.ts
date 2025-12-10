import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: 'products',
    loadChildren: () =>
      import('./components/products/products.route').then(m => m.PRODUCTS_ROUTES)
  },
  { path: '', redirectTo: 'products', pathMatch: 'full' }
];
