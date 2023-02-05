import { Component, OnInit } from '@angular/core';
import {AccountService} from "../../services/account.service";
import { FormControl, FormGroup} from "@angular/forms";
import { MatDialogRef} from "@angular/material/dialog";
import { AddFromCard, Card} from "../../../../models/card";

@Component({
  selector: 'app-add-from-card',
  templateUrl: './add-from-card.component.html',
  styleUrls: ['./add-from-card.component.scss']
})
export class AddFromCardComponent implements OnInit {

  public formGroup: FormGroup = new FormGroup({
      username: new FormControl(),
      idCard: new FormControl(),
      amount: new FormControl(),
    }
  );

  constructor(
    private accountService: AccountService,
    public dialogRef: MatDialogRef<AddFromCard>,
  ){}

  ngOnInit(): void { }

  public addFromCard(): void {
    this.accountService.addFromCard(this.formGroup.value as AddFromCard)
      .subscribe({
        next: (result) => {
          this.dialogRef.close(result);
          console.log('Money added!');
        }
      });
  }

}
