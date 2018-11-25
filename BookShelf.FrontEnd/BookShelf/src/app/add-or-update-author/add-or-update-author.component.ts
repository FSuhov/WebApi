import { Component, EventEmitter, Output, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-add-or-update-author',
  templateUrl: './add-or-update-author.component.html',
  styleUrls: ['./add-or-update-author.component.css']
})
export class AddOrUpdateAuthorComponent implements OnInit {

  @Output() authorCreated = new EventEmitter<any>();
  @Input() authorInfo: any;

  public buttonText = 'Save';

  constructor() {
    this.clearAuthorInfo();
    console.log(this.authorInfo.name);
  }

  ngOnInit() {
  }

  private clearAuthorInfo = function () {
    // Create an empty object
    this.authorInfo = {
      id: undefined,
      name: ''
    };
  };

  public addOrUpdateAuthorRecord = function (event) {
    this.authorCreated.emit(this.authorInfo);
    this.clearAuthorInfo();
  };
}
