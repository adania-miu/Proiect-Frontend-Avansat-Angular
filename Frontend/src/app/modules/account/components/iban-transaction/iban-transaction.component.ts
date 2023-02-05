import { Component, OnInit } from '@angular/core';
import {AccountService} from "../../services/account.service";
import { FormControl, FormGroup} from "@angular/forms";
import { MatDialogRef} from "@angular/material/dialog";
import {SendIban} from "../../../../models/send-iban";
import {SendUser} from "../../../../models/send-user";

@Component({
  selector: 'app-iban-transaction',
  templateUrl: './iban-transaction.component.html',
  styleUrls: ['./iban-transaction.component.scss']
})
export class IbanTransactionComponent implements OnInit {

  public transactionForm: FormGroup = new FormGroup({
      IBAN1: new FormControl(),
      suma: new FormControl(),
      IBAN2: new FormControl()
    }
  );

  constructor(
    private accountService: AccountService,
    public dialogRef: MatDialogRef<IbanTransactionComponent>,
  ){}

  ngOnInit(): void { }

  public sendIBAN(): void {
    this.accountService.sendIBAN(this.transactionForm.value as SendIban)
      .subscribe({
        next: (result) => {
          this.dialogRef.close(result);
          console.log('Transaction done!');
        }
      });
  }

}
