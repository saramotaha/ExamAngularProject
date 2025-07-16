import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router, RouterLink, RouterLinkActive, RouterOutlet } from '@angular/router';
import { RoleService } from '../../Services/role-service';
import { CommonModule } from '@angular/common';



@Component({
  selector: 'app-dashboard',
  imports: [RouterLink,CommonModule],
  templateUrl: './dashboard.html',
  styleUrl: './dashboard.css'
})
export class Dashboard implements OnInit {

  roleName!: string;

  constructor(private route: Router, private role: RoleService) { }


  ngOnInit(): void {
    this.role.getRole().subscribe({
      next: (response) => {

        this.roleName = response.role;
        console.log(this.roleName);
      }
    })

  }




  logOut() {
    localStorage.removeItem("token");
    this.route.navigate(['/Login']);
    // window.location.reload();

  }



}
