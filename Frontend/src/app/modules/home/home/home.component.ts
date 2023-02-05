import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import {AccountService} from "../../account/services/account.service";
import {IUser} from "../../../models/user";
import {Router} from "@angular/router";
import { MatSidenav } from "@angular/material/sidenav";
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  @ViewChild('sidenav')
  sidenav!: MatSidenav;
  isLoggedIn: boolean = false;
  userId: number | null = null;

  constructor(private accountService: AccountService, private router: Router) {}

  ngOnInit() {
    // this.accountService.currentUser$
    //   .subscribe((user: IUser | null) => {
    //     this.isLoggedIn = !!user;
    //     if (user) {
    //       this.userId = user.id;
    //     }
    //   });
  }

  // logOut() {
  //   this.accountService.logout();
  //   this.router.navigateByUrl('/refresh', { skipLocationChange: true })
  //     .then(() => this.router.navigate(['/']));
  // }
}
