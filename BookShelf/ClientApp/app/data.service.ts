﻿import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Genre } from './genre';

@Injectable()
export class DataService {

    private url = "/api/genre";

    constructor(private http: HttpClient) {
    }

    getGenres() {
        return this.http.get(this.url);
    }

    addGenre(genre: Genre) {
        return this.http.post(this.url, genre, { observe: 'response' });
    }
    updateGenre(genre: Genre) {

        return this.http.put(this.url + '/' + genre.id, genre);
    }
    deleteGenre(id: number) {
        return this.http.delete(this.url + '/' + id);
    }
}