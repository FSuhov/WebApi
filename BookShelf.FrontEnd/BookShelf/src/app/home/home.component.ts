import { Component, OnInit } from '@angular/core';
import { GenreService } from '../genre.service';
import * as _ from 'lodash';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  public genreData: Array<any>;
  public currentGenre: any;

  //constructor() { }

  constructor(private genreService: GenreService) {
    genreService.get().subscribe((data: any) => this.genreData = data);
    this.currentGenre = this.setInitialValuesForGenreData();
  }

  //ngOnInit() {
  //}

  private setInitialValuesForGenreData() {
    return {
      id: undefined,
      name: '',     
    }
  }

  public createOrUpdateGenre = function (genre: any) {
    // if genre is present in genreData, we can assume this is an update
    // otherwise it is adding a new element
    let genreWithId;
    genreWithId = _.find(this.genreData, (el => el.id === genre.id));

    if (genreWithId) {
      const updateIndex = _.findIndex(this.genreData, { id: genreWithId.id });
      this.genreService.update(genre).subscribe(
        genreRecord => this.genreData.splice(updateIndex, 1, genre)
      );
    } else {
      this.genreService.add(genre).subscribe(
        genreRecord => this.genreData.push(genre)
      );
    }

    this.currentGenre = this.setInitialValuesForGenreData();
  };

  public editClicked = function (record) {
    this.currentGenre = record;
  };

  public newClicked = function () {
    this.currentGenre = this.setInitialValuesForGenregData();
  };

  public deleteClicked(record) {
    const deleteIndex = _.findIndex(this.genreData, { id: record.id });
    this.genreService.remove(record).subscribe(
      result => this.genreData.splice(deleteIndex, 1)
    );
  }
}
