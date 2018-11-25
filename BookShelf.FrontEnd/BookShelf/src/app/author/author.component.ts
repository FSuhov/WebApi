import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
import { AuthorService } from '../author.service';
import * as _ from 'lodash';

@Component({
  selector: 'app-author',
  templateUrl: './author.component.html',
  styleUrls: ['./author.component.css']
})
export class AuthorComponent  {  

  //constructor() { }
  public authorData: Array<any>;
  public currentAuthor: any;
  constructor(private authorService: AuthorService) {
    authorService.get().subscribe((data: any) => this.authorData = data);
    this.currentAuthor = this.setInitialValuesForAuthorData();
  }
  //ngOnInit() {
  //}

  private setInitialValuesForAuthorData() {
    return {
      id: undefined,
      name: '',
    }
  }

  public createOrUpdateAuthor = function (author: any) {    
    let authorWithId;
    authorWithId = _.find(this.authorData, (el => el.id === author.id));

    if (authorWithId) {
      const updateIndex = _.findIndex(this.authorData, { id: authorWithId.id });
      this.authorService.update(author).subscribe(
        authorRecord => this.authorData.splice(updateIndex, 1, author)
      );
    } else {
      this.authorService.add(author).subscribe(
        authorRecord => this.authorData.push(author)
      );
    }

    this.currentAuthor = this.setInitialValuesForAuthorData();
  };

  public editClicked = function (record) {
    this.currentAuthor = record;
  };

  public newClicked = function () {
    this.currentAuthor = this.setInitialValuesForAuthorData();
  };

  public deleteClicked(record) {
    const deleteIndex = _.findIndex(this.authorData, { id: record.id });
    this.authorService.remove(record).subscribe(
      result => this.authorData.splice(deleteIndex, 1)
    );
  }

  public deleteRecord(record) {
    this.deleteClicked(record);
  }

  public editRecord(record) {
    const clonedRecord = Object.assign({}, record);
    this.editClicked(clonedRecord);
  }
}
