import {Component, OnInit} from '@angular/core';
import {AccountService} from "../../services/account.service";
import { FormControl, FormGroup} from "@angular/forms";
import { MatDialogRef} from "@angular/material/dialog";
import {SendUser} from "../../../../models/send-user";
@Component({
  selector: 'app-user-transaction',
  templateUrl: './user-transaction.component.html',
  styleUrls: ['./user-transaction.component.scss']
})
export class UserTransactionComponent implements OnInit {

  public transactionForm: FormGroup = new FormGroup({
      username1: new FormControl(),
      suma: new FormControl(),
      username2: new FormControl()
    }
  );

  constructor(
    private accountService: AccountService,
    public dialogRef: MatDialogRef<UserTransactionComponent>,
  ){}

  ngOnInit(): void { }

  public sendUser(): void {
    this.accountService.sendUser(this.transactionForm.value as SendUser)
      .subscribe({
        next: (result) => {
          this.dialogRef.close(result);
          console.log('Transaction done!');
        }
      });
  }

}
