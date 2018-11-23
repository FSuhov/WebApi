import { Component, OnInit } from '@angular/core';
import { DataService } from './data.service';
import { Genre } from './genre';

import { HttpResponse } from '@angular/common/http';

@Component({
    selector: 'app',
    templateUrl: './app.component.html',
    providers: [DataService]
})
export class AppComponent implements OnInit {

    genre: Genre = new Genre();   // изменяемый товар
    genres: Genre[];                // массив товаров
    tableMode: boolean = true;          // табличный режим

    constructor(private dataService: DataService) { }

    ngOnInit() {
        this.loadGenres();    // загрузка данных при старте компонента  
    }
    // получаем данные через сервис
    loadGenres() {
        this.dataService.getGenres()
            .subscribe((data: Genre[]) => this.genres = data);
    }
    // сохранение данных
    save() {
        if (this.genre.id == null) {
            this.dataService.addGenre(this.genre)
                .subscribe((data: HttpResponse<Genre>) => {
                    console.log(data);
                    this.genres.push(data.body);
                });
        } else {
            this.dataService.updateGenre(this.genre)
                .subscribe(data => this.loadGenres());
        }
        this.cancel();
    }
    editProduct(p: Genre) {
        this.genre = p;
    }
    cancel() {
        this.genre = new Genre();
        this.tableMode = true;
    }
    delete(p: Genre) {
        this.dataService.deleteGenre(p.id)
            .subscribe(data => this.loadGenres());
    }
    add() {
        this.cancel();
        this.tableMode = false;
    }
}