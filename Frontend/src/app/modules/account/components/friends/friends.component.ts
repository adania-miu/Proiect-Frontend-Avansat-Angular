import {Component, ViewChild} from '@angular/core';
import {MatSidenav} from "@angular/material/sidenav";
import {AccountService} from "../../services/account.service";
import {ToastrService} from "ngx-toastr";
import {Friend, IFriend} from "../../../../models/friend";
import {MatDialog, MatDialogConfig} from "@angular/material/dialog";
import {AddCardComponent} from "../add-card/add-card.component";
import {AddFriendComponent} from "../add-friend/add-friend.component";
import {User, Username} from "../../../../models/user";
import {FormControl, FormGroup} from "@angular/forms";

@Component({
  selector: 'app-friends',
  templateUrl: './friends.component.html',
  styleUrls: ['./friends.component.scss']
})
export class FriendsComponent {

  public formGroup: FormGroup = new FormGroup({
      username: new FormControl(),
    }
  );

  public friend: Friend[] = [];

  public friend2: IFriend[] = [];

  public displayedColumns = ['username'];

  @ViewChild('sidenav')
  sidenav!: MatSidenav;

  constructor(
    public dialog: MatDialog,
    private accountService: AccountService,
  ) { }

  public getFriends(username: Username) {
    this.accountService.getUserFriends(username).subscribe(
      (result: IFriend[]) => {
        this.friend2 = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }

  public openModal(friend?): void {
    const data = {
      friend
    };
    const dialogConfig = new MatDialogConfig();
    dialogConfig.width = '550px';
    dialogConfig.height = '700px';
    dialogConfig.data = data;
    const dialogRef = this.dialog.open(AddFriendComponent, dialogConfig);
    dialogRef.afterClosed().subscribe((result) => {
      if (result) {
        this.friend = result;
      }
    });
  }

  public addNewFriend(): void {
    this.openModal();
  }

  toggleSidenav(): void {
    this.sidenav.toggle();
  }
}
