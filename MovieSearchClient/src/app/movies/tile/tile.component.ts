import { Component, input } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { Movie } from '../movie';

@Component({
  selector: 'app-movie-tile',
  standalone: true,
  imports: [MatButtonModule],
  templateUrl: './tile.component.html',
  styleUrl: './tile.component.scss',
})
export class TileComponent {
  public movie = input<Movie>({ title: '', releaseYear: 0, poster: '' });
}
