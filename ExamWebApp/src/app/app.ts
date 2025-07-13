import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Home } from "./Pages/home/home";
import { Nav } from "./LayOut/nav/nav";
import { Footer } from "./LayOut/footer/footer";

@Component({
  selector: 'app-root',
  imports: [Nav, Footer, RouterOutlet],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected title = 'ExamWebApp';
}
