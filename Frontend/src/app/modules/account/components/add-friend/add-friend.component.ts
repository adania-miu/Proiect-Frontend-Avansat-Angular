import { Component, OnInit} from '@angular/core';
import {AccountService} from "../../services/account.service";
import { FormControl, FormGroup} from "@angular/forms";
import { MatDialogRef} from "@angular/material/dialog";
import { Friend} from "../../../../models/friend";

@Component({
  selector: 'app-add-friend',
  templateUrl: './add-friend.component.html',
  styleUrls: ['./add-friend.component.scss']
})
export class AddFriendComponent implements OnInit {
  public friendForm: FormGroup = new FormGroup({
      username1: new FormControl(),
      username2: new FormControl(),
    }
  );

  constructor(
    private accountService: AccountService,
    public dialogRef: MatDialogRef<AddFriendComponent>,
  ){}

  ngOnInit(): void { }

  public addFriend(): void {
    this.accountService.addFriend(this.friendForm.value as Friend)
      .subscribe({
        next: (result) => {
          this.dialogRef.close(result);
          console.log('Friend added!');
        }
      });
  }
}
