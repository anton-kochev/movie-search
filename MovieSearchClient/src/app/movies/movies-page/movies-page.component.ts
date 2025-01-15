import { CommonModule } from '@angular/common';
import { Component, inject } from '@angular/core';
import { MovieSearchCriteria } from '@app-core/models/movie-search-criteria';
import { DisplayComponent } from '../display/display.component';
import { MoviesFacadeService } from '../movies-facade.service';
import { SearchComponent } from '../search/search.component';

@Component({
  imports: [CommonModule, DisplayComponent, SearchComponent],
  providers: [MoviesFacadeService],
  selector: 'app-movies-page',
  standalone: true,
  styleUrl: './movies-page.component.scss',
  templateUrl: './movies-page.component.html',
})
export class MoviesPageComponent {
  private readonly moviesFacade = inject(MoviesFacadeService);
  public readonly error$ = this.moviesFacade.error$;
  public readonly loading$ = this.moviesFacade.loading$;
  public readonly movies$ = this.moviesFacade.movies$;

  public onSearchCriteriaChanged(event: MovieSearchCriteria): void {
    this.moviesFacade.searchMovies(event);
  }
}
