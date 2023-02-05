import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AccountRoutingModule } from './account-routing.module';
import { LoginComponent } from './components/login/login.component';
import { ProfileComponent } from './components/profile/profile.component';
import { SignupComponent } from './components/signup/signup.component';
import { MatFormFieldModule } from "@angular/material/form-field";
import { ReactiveFormsModule } from "@angular/forms";
import { MatProgressBarModule } from "@angular/material/progress-bar";
import { MatCardModule } from "@angular/material/card";
import { MatProgressSpinnerModule } from "@angular/material/progress-spinner";
import { MatInputModule } from "@angular/material/input";
import { MatButtonModule } from "@angular/material/button";
import { ErrorDirective } from './directives/error.directive';
import { UiModule } from "../ui/ui.module";
import {MatToolbarModule} from "@angular/material/toolbar";
import {MatSidenavModule} from "@angular/material/sidenav";
import {MatIconModule} from "@angular/material/icon";
import { CardsComponent } from './components/cards/cards.component';
import { FriendsComponent } from './components/friends/friends.component';
import { TransactionsComponent } from './components/transactions/transactions.component';
import { AddCardComponent } from './components/add-card/add-card.component';
import { AddFriendComponent } from './components/add-friend/add-friend.component';
import { UserTransactionComponent } from './components/user-transaction/user-transaction.component';
import { IbanTransactionComponent } from './components/iban-transaction/iban-transaction.component';
import { AddFromCardComponent } from './components/add-from-card/add-from-card.component';
import {MatTableModule} from "@angular/material/table";
@NgModule({
  declarations: [
    LoginComponent,
    ProfileComponent,
    SignupComponent,
    ErrorDirective,
    CardsComponent,
    FriendsComponent,
    TransactionsComponent,
    AddCardComponent,
    AddFriendComponent,
    UserTransactionComponent,
    IbanTransactionComponent,
    AddFromCardComponent
  ],
  imports: [
    CommonModule,
    AccountRoutingModule,
    MatFormFieldModule,
    ReactiveFormsModule,
    MatProgressBarModule,
    MatCardModule,
    MatProgressSpinnerModule,
    MatInputModule,
    MatButtonModule,
    UiModule,
    MatToolbarModule,
    MatSidenavModule,
    MatIconModule,
    MatTableModule
  ]
})
export class AccountModule { }
