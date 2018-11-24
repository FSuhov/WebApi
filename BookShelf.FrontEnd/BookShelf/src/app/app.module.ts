import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { GenreComponentComponent } from './genre-component/genre-component.component';

import { GenreService } from './genre.service';
import { HttpClientModule } from '@angular/common/http';
import { AddOrUpdateGenreComponent } from './add-or-update-genre/add-or-update-genre.component';

const appRoutes: Routes = [
  { path: '', component: HomeComponent }

];

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    GenreComponentComponent,
    AddOrUpdateGenreComponent
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot(appRoutes),
    HttpClientModule,
    FormsModule
  ],
  providers: [GenreService],
  bootstrap: [AppComponent]
})
export class AppModule { }
