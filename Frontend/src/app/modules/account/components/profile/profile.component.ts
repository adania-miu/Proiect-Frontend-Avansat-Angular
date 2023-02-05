import { Component, ViewChild } from '@angular/core';
import {IUser, Username, User, Sold} from "../../../../models/user";
import {AccountService} from "../../services/account.service";
import { FormControl, FormGroup} from "@angular/forms";
import { MatSidenav } from "@angular/material/sidenav";
@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})
export class ProfileComponent {

  public formGroup: FormGroup = new FormGroup({
      username: new FormControl(),
    }
  );
  public user: User[] = [];

  public sold: Sold[] = [];

  public displayedColumns = ['userName', 'email', 'firstName', 'lastName', 'iban'];

  public displayedColumns2 = ['sold'];


  @ViewChild('sidenav')
  sidenav!: MatSidenav;

  constructor(
    private accountService: AccountService
  ) { }

  public getUser(username: Username) {
    this.accountService.getUserDetails(username).subscribe(
      (result: User[]) => {
        this.user = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }

  public getSold(username: Username) {
    this.accountService.getSoldValue(username).subscribe(
      (result: Sold[]) => {
        this.sold = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }

  toggleSidenav(): void {
    this.sidenav.toggle();
  }
}
