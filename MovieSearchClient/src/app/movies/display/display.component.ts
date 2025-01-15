import { Component, input } from '@angular/core';
import { Movie } from '../movie';
import { TileComponent } from '../tile/tile.component';

@Component({
  imports: [TileComponent],
  selector: 'app-movie-display',
  standalone: true,
  styleUrl: './display.component.scss',
  templateUrl: './display.component.html',
})
export class DisplayComponent {
  public readonly error = input<boolean>(false);
  public readonly movies = input<Movie[]>([]);
}
