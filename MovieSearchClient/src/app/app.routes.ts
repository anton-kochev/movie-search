import { Routes } from '@angular/router';
import { MoviesFacadeService } from './movies/movies-facade.service';

export const routes: Routes = [
  {
    path: 'movies',
    loadComponent: () =>
      import('./movies/movies-page/movies-page.component').then(
        c => c.MoviesPageComponent,
      ),
    providers: [MoviesFacadeService],
  },
  { path: '', redirectTo: '/movies', pathMatch: 'full' },
];
