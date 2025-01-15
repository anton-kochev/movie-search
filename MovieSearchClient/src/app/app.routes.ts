import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: 'movies',
    loadComponent: () =>
      import('./movies/movies-page/movies-page.component').then(
        c => c.MoviesPageComponent,
      ),
  },
  { path: '', redirectTo: '/movies', pathMatch: 'full' },
];
