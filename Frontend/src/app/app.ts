import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Header } from './shared/header/header';
import { Menu } from './shared/menu/menu';

@Component({
	selector: 'app-root',
	templateUrl: './app.html',
	styleUrl: './app.scss',
	imports: [
		RouterOutlet,
		Header,
		Menu
	],
})
export class App {
	protected readonly title = signal('JEXample');
}
