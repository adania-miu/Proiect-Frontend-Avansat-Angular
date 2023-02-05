import {Component, OnInit, ViewChild} from '@angular/core';
import {MatSidenav} from "@angular/material/sidenav";
import {AddCardComponent} from "../add-card/add-card.component";
import {Card} from "../../../../models/card";
import {MatDialog, MatDialogConfig} from "@angular/material/dialog";
import {AddFromCardComponent} from "../add-from-card/add-from-card.component";
import {AccountService} from "../../services/account.service";
import {FormControl, FormGroup} from "@angular/forms";
import {Username} from "../../../../models/user";
@Component({
  selector: 'app-cards',
  templateUrl: './cards.component.html',
  styleUrls: ['./cards.component.scss']
})
export class CardsComponent {

  public cardForm: FormGroup = new FormGroup({
      username: new FormControl(),
    }
  );

  public cards2: Card[] = [];

  public cards: Card[] = [];
  public displayedColumns = ['pin', 'cvv', 'monthExp', 'yearExp'];


  @ViewChild('sidenav')
  sidenav!: MatSidenav;


  constructor(
    private accountService: AccountService,
    public dialog: MatDialog,

  ) { }


  public GetCards(username: Username) {
    this.accountService.getUserCards(username).subscribe(
      (result: Card[]) => {
        this.cards2 = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }

  public openModal(card?): void {
    const data = {
      card
    };
    const dialogConfig = new MatDialogConfig();
    dialogConfig.width = '550px';
    dialogConfig.height = '700px';
    dialogConfig.data = data;
    const dialogRef = this.dialog.open(AddCardComponent, dialogConfig);
    dialogRef.afterClosed().subscribe((result) => {
      if (result) {
        this.cards = result;
      }
    });
  }

  public addNewCard(): void {
    this.openModal();
  }

  public openModal2(card?): void {
    const data = {
      card
    };
    const dialogConfig = new MatDialogConfig();
    dialogConfig.width = '550px';
    dialogConfig.height = '700px';
    dialogConfig.data = data;
    const dialogRef = this.dialog.open(AddFromCardComponent, dialogConfig);
    dialogRef.afterClosed().subscribe((result) => {
      if (result) {
        this.cards = result;
      }
    });
  }

  public addMoneyFromCard(): void {
    this.openModal2();
  }

  toggleSidenav(): void {
    this.sidenav.toggle();
  }
}
