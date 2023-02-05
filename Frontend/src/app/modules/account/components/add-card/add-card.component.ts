import { Component, OnInit} from '@angular/core';
import {AccountService} from "../../services/account.service";
import { FormControl, FormGroup} from "@angular/forms";
import { MatDialogRef} from "@angular/material/dialog";
import {Card} from "../../../../models/card";

@Component({
  selector: 'app-add-card',
  templateUrl: './add-card.component.html',
  styleUrls: ['./add-card.component.scss']
})
export class AddCardComponent implements OnInit {

  public cardForm: FormGroup = new FormGroup({
      username: new FormControl(),
      pin: new FormControl(),
      cvv: new FormControl(),
      monthExp: new FormControl(),
      yearExp: new FormControl(),
      sold: new FormControl(),
    }
  );

  constructor(
    private accountService: AccountService,
    public dialogRef: MatDialogRef<AddCardComponent>,
  ){}

  ngOnInit(): void { }

  public addCard(): void {
    this.accountService.addCard(this.cardForm.value.username, this.cardForm.value as Card)
      .subscribe({
        next: (result) => {
          this.dialogRef.close(result);
          console.log('Card added!');
        }
      });
  }


}
