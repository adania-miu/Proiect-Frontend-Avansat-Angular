import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from "./components/login/login.component";
import { SignupComponent } from "./components/signup/signup.component";
import { ProfileComponent } from "./components/profile/profile.component";
import { AuthGuard } from "./guards/auth.guard";
import { HomeComponent } from "../home/home/home.component";
import { CardsComponent} from "./components/cards/cards.component";
import { FriendsComponent} from "./components/friends/friends.component";
import { TransactionsComponent} from "./components/transactions/transactions.component";

const routes: Routes = [
  {
    path: 'home',
    component: HomeComponent
  },
  {
    path: 'login',
    component: LoginComponent
  },
  {
    path: 'signup',
    component: SignupComponent
  },
  {
    path: 'profile',
    component: ProfileComponent,
    //canActivate: [AuthGuard]
  },
  {
    path: 'cards',
    component: CardsComponent,
  //canActivate: [AuthGuard]
  },
  {
    path: 'transactions',
    component: TransactionsComponent,
    //canActivate: [AuthGuard]
  },
  {
    path: 'friends',
    component: FriendsComponent,
    //canActivate: [AuthGuard]
  },


];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AccountRoutingModule { }
