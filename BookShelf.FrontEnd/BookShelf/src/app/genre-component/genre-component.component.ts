import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-genre-component',
  templateUrl: './genre-component.component.html',
  styleUrls: ['./genre-component.component.css']
})
export class GenreComponentComponent implements OnInit {

  @Output() recordDeleted = new EventEmitter<any>();
  @Output() newClicked = new EventEmitter<any>();
  @Output() editClicked = new EventEmitter<any>();
  @Input() genreData: Array<any>;

  constructor() { }

  ngOnInit() {
  }

  public deleteRecord(record) {
    this.recordDeleted.emit(record);
  }

  public editRecord(record) {
    const clonedRecord = Object.assign({}, record);
    this.editClicked.emit(clonedRecord);
  }

  public newRecord() {
    this.newClicked.emit();
  }
}
