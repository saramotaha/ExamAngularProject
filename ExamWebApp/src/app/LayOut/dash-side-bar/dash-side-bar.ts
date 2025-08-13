import { Component, OnInit } from '@angular/core';
import { RoleService } from '../../Services/role-service';
import { Router, RouterLink } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-dash-side-bar',
  imports: [RouterLink , CommonModule],
  templateUrl: './dash-side-bar.html',
  styleUrl: './dash-side-bar.css'
})
export class DashSideBar implements OnInit {

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
