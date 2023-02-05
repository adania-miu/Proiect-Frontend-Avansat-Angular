import { Component, OnDestroy, OnInit, ViewChild  } from '@angular/core';
import {NavigationEnd, Router} from "@angular/router";
import {AccountService} from "./modules/account/services/account.service";
import { MatSidenav } from "@angular/material/sidenav";
import {IUser} from "./models/user";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  @ViewChild('sidenav')
  sidenav!: MatSidenav;

  title = 'EasyCard';
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

