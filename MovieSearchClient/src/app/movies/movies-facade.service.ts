import { inject, Injectable } from '@angular/core';
import { MoviesApiServiceService } from '@app-core/api/movies-api-service';
import { MovieSearchCriteria } from '@app-core/models/movie-search-criteria';
import { catchError, Observable, of, Subject, switchMap, tap } from 'rxjs';
import { Movie } from './movie';

@Injectable()
export class MoviesFacadeService {
  private readonly moviesApiService = inject(MoviesApiServiceService);

  private readonly criteria = new Subject<MovieSearchCriteria>();
  private readonly loading = new Subject<boolean>();
  private readonly error = new Subject<string>();

  public readonly loading$: Observable<boolean>;
  public readonly movies$: Observable<Movie[]>;

  constructor() {
    this.movies$ = this.criteria.pipe(
      tap(() => {
        this.loading.next(true);
        this.error.next('');
      }),
      switchMap(criteria =>
        this.moviesApiService.getMovies(criteria).pipe(
          catchError(error => {
            this.error.next(error);

            return of([]);
          }),
          tap(() => this.loading.next(false)),
        ),
      ),
    );
    this.loading$ = this.loading.asObservable();
  }

  public searchMovies(criteria: MovieSearchCriteria): void {
    this.criteria.next(criteria);
  }
}
