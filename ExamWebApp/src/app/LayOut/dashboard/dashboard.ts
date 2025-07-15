import { Component } from '@angular/core';
import { ActivatedRoute, Router, RouterLink, RouterLinkActive, RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-dashboard',
  imports: [RouterLink],
  templateUrl: './dashboard.html',
  styleUrl: './dashboard.css'
})
export class Dashboard {

  constructor(private route :Router) { }


  logOut() {
    console.log("ssssssss");



    localStorage.removeItem("token");
    this.route.navigate(['/Login']);

  }

}
