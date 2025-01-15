import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Movie } from '../../movies/movie';
import { MovieSearchCriteria } from '../models/movie-search-criteria';
import { BaseApiService } from './base-api.service';

@Injectable()
export class MoviesApiServiceService extends BaseApiService {
  public getMovies(search: MovieSearchCriteria): Observable<Movie[]> {
    return this.get(`api/movies?s=${search.title}`);
  }
}
