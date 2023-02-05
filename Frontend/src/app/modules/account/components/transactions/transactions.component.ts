import {Component, ViewChild} from '@angular/core';
import {MatSidenav} from "@angular/material/sidenav";
import {UserTransactionComponent} from "../user-transaction/user-transaction.component";
import {SendUser} from "../../../../models/send-user";
import {MatDialog, MatDialogConfig} from "@angular/material/dialog";
import {Router} from "@angular/router";
import {Card} from "../../../../models/card";
import {AddCardComponent} from "../add-card/add-card.component";
import {IbanTransactionComponent} from "../iban-transaction/iban-transaction.component";
import {SendIban} from "../../../../models/send-iban";

@Component({
  selector: 'app-transactions',
  templateUrl: './transactions.component.html',
  styleUrls: ['./transactions.component.scss']
})
export class TransactionsComponent {

  public sendUser: SendUser[] = [];

  public sendIBAN: SendIban[] = [];

  @ViewChild('sidenav')
  sidenav!: MatSidenav;

  constructor(
    public dialog: MatDialog,
  ) { }

  public openModal(transaction?): void {
    const data = {
      transaction
    };
    const dialogConfig = new MatDialogConfig();
    dialogConfig.width = '550px';
    dialogConfig.height = '700px';
    dialogConfig.data = data;
    const dialogRef = this.dialog.open(UserTransactionComponent, dialogConfig);
    dialogRef.afterClosed().subscribe((result) => {
      if (result) {
        this.sendUser = result;
      }
    });
  }

  public sendToUser(): void {
    this.openModal();
  }

  public openModal2(transaction?): void {
    const data = {
      transaction
    };
    const dialogConfig = new MatDialogConfig();
    dialogConfig.width = '550px';
    dialogConfig.height = '700px';
    dialogConfig.data = data;
    const dialogRef = this.dialog.open(IbanTransactionComponent, dialogConfig);
    dialogRef.afterClosed().subscribe((result) => {
      if (result) {
        this.sendIBAN = result;
      }
    });
  }

  public sendToIBAN(): void {
    this.openModal2();
  }


  toggleSidenav(): void {
    this.sidenav.toggle();
  }
}
