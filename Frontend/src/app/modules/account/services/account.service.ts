import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {BehaviorSubject, map, Observable, switchMap, tap} from "rxjs";
import {IUser, IUserLogin, IUserSignup, Sold, User, Username} from "../../../models/user";
import {AddFromCard, Card} from "../../../models/card";
import {SendUser} from "../../../models/send-user";
import {Friend, IFriend} from "../../../models/friend";
import {SendIban} from "../../../models/send-iban";

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  // private currentUserSubject: BehaviorSubject<IUser | null>;

  public apiUrl = 'https://localhost:44332/api'

  // currentUser$: Observable<IUser | null>;

  // get currentUser(): IUser | null {
  //   return this.currentUserSubject.value;
  // }

  constructor(private httpClient: HttpClient) {
    // const userJson = localStorage.getItem('user');
    // this.currentUserSubject = new BehaviorSubject<IUser | null>(userJson ? JSON.parse(userJson) : null);
    // this.currentUser$ = this.currentUserSubject.asObservable();
  }


  signUp(user: IUserSignup): Observable<any> {
    return this.httpClient.post(`${this.apiUrl}/Auth/register`, user, {responseType: 'text'});
  }

  login(user: IUserLogin) {
    return this.httpClient.post(`${this.apiUrl}/Auth/login`, user, { responseType: 'text' });
      // .pipe(
      //   switchMap((token: string) => {
      //     localStorage.setItem('token', token);
      //     return this.refreshCurrentUser();
      //   })
      // );
  }

  // logout(): void {
  //   localStorage.removeItem('token');
  //   localStorage.removeItem('user');
  //   this.currentUserSubject.next(null);
  // }

  // refreshCurrentUser(): Observable<any> {
  //   return this.me().pipe(tap((me: Partial<IUser>) => {
  //     const user = {
  //       token: localStorage.getItem('token')!,
  //       ...me
  //     } as IUser;
  //     localStorage.setItem('user', JSON.stringify(user));
  //     this.currentUserSubject.next(user);
  //   }));
  // }
  //
  // me(): Observable<Partial<IUser>> {
  //   return this.httpClient.get<IUser>(`${this.apiUrl}/User/getUserByName`);
  // }

  public getUserCards(username: Username): Observable<Card[]> {
    return this.httpClient.get<Card[]>(`${this.apiUrl}/User/getUserCards?username=${username.username}`);
  }

  public getSoldValue(username: Username): Observable<Sold[]> {
    return this.httpClient.get<Sold[]>(`${this.apiUrl}/User/checkSold?username=${username.username}`);
  }

  public getUserDetails(username: Username): Observable<User[]> {
    return this.httpClient.get<User[]>(`${this.apiUrl}/User/getUserByName?username=${username.username}`);
  }

  public getUserFriends(username: Username): Observable<IFriend[]> {
    return this.httpClient.get<IFriend[]>(`${this.apiUrl}/User/getUserFriends?username=${username.username}`);
  }


  public addCard(username: Username, card: Card): Observable<any> {
    return this.httpClient.post(`${this.apiUrl}/Card/addCardToUser?username=${username}`, card, {responseType: 'text'});
  }
  public addFromCard(sold: AddFromCard): Observable<any> {
    return this.httpClient.put(`${this.apiUrl}/User/addMoneyFromCard?username=${sold.username}&idCard=${sold.idCard}&amount=${sold.amount}`, sold, {responseType: 'text'});
  }

  public sendUser(sendUser: SendUser): Observable<any> {
    return this.httpClient.post(`${this.apiUrl}/Tranzactie/createTransactionWithUsername?username1=${sendUser.username1}&suma=${sendUser.suma}&username2=${sendUser.username2}`, sendUser,{responseType: 'text'});
  }

  public sendIBAN(sendIBAN: SendIban): Observable<any> {
    return this.httpClient.post(`${this.apiUrl}/Tranzactie/createTransactionWithIBAN?IBAN1=${sendIBAN.IBAN1}&suma=${sendIBAN.suma}&IBAN2=${sendIBAN.IBAN2}`, sendIBAN,{responseType: 'text'});
  }

  public addFriend(addFriend: Friend): Observable<any> {
    return this.httpClient.post(`${this.apiUrl}/Friend/addFriend?username1=${addFriend.username1}&username2=${addFriend.username2}`, addFriend,{responseType: 'text'});
  }

}
