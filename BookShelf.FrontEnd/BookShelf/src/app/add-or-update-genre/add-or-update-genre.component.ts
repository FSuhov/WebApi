import { Component, EventEmitter, Output, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-add-or-update-genre',
  templateUrl: './add-or-update-genre.component.html',
  styleUrls: ['./add-or-update-genre.component.css']
})
export class AddOrUpdateGenreComponent implements OnInit {
  @Output() genreCreated = new EventEmitter<any>();
  @Input() genreInfo: any;

  public buttonText = 'Save';

  constructor() {
    this.clearGenreInfo();
    console.log(this.genreInfo.name);
  }  

  ngOnInit() {
  }

  private clearGenreInfo = function () {
    // Create an empty genre object
    this.genreInfo = {
      id: undefined,
      name: ''
    };
  };

  public addOrUpdateGenreRecord = function (event) {
    this.genreCreated.emit(this.genreInfo);
    this.clearGenreInfo();
  };
}
