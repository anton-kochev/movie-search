import { Component, input, output } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInput } from '@angular/material/input';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MovieSearchCriteria } from '@app-core/models/movie-search-criteria';
import { debounceTime, distinctUntilChanged, map } from 'rxjs';

@Component({
  selector: 'app-movie-search',
  standalone: true,
  imports: [
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInput,
    MatProgressSpinnerModule,
  ],
  templateUrl: './search.component.html',
  styleUrl: './search.component.scss',
})
export class SearchComponent {
  public readonly loading = input<boolean>(false);
  public searchCriteriaChanged = output<MovieSearchCriteria>();

  public readonly searchForm = new FormGroup({
    title: new FormControl<string>(''),
  });

  constructor() {
    this.searchForm.valueChanges
      .pipe(
        debounceTime(500),
        map(() => this.searchForm.getRawValue()),
        distinctUntilChanged(),
      )
      .subscribe(value => {
        this.searchCriteriaChanged.emit({ title: value.title ?? '' });
      });
  }
}
