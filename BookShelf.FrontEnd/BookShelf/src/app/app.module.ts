import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { GenreComponentComponent } from './genre-component/genre-component.component';

import { GenreService } from './genre.service';
import { AuthorService } from './author.service';
import { HttpClientModule } from '@angular/common/http';
import { AddOrUpdateGenreComponent } from './add-or-update-genre/add-or-update-genre.component';
import { AuthorComponent } from './author/author.component';
import { AddOrUpdateAuthorComponent } from './add-or-update-author/add-or-update-author.component';

const appRoutes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'author', component: AuthorComponent }
];

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    GenreComponentComponent,
    AddOrUpdateGenreComponent,
    AuthorComponent,
    AddOrUpdateAuthorComponent
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot(appRoutes),
    HttpClientModule,
    FormsModule
  ],
  providers: [GenreService, AuthorService],
  bootstrap: [AppComponent]
})
export class AppModule { }
