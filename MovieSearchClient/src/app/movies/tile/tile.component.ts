import { Component, input } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { Movie } from '../movie';

@Component({
  selector: 'app-movie-tile',
  standalone: true,
  imports: [MatCardModule, MatButtonModule],
  templateUrl: './tile.component.html',
  styleUrl: './tile.component.scss',
})
export class TileComponent {
  public movie = input<Movie>({ title: '', releaseYear: 0, poster: '' });
}
