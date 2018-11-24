import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddOrUpdateGenreComponent } from './add-or-update-genre.component';

describe('AddOrUpdateGenreComponent', () => {
  let component: AddOrUpdateGenreComponent;
  let fixture: ComponentFixture<AddOrUpdateGenreComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddOrUpdateGenreComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddOrUpdateGenreComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
