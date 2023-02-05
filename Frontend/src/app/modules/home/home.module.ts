import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatToolbarModule} from "@angular/material/toolbar";
import {ToastrModule} from "ngx-toastr";
import {JwtModule} from "@auth0/angular-jwt";

import {MatIconModule} from "@angular/material/icon";
import {MatChipsModule} from "@angular/material/chips";
import {MatRadioModule} from "@angular/material/radio";
import {MatCheckboxModule} from "@angular/material/checkbox";

import { MatButtonModule } from "@angular/material/button";
import { HttpClientModule } from "@angular/common/http";
import { FormsModule } from "@angular/forms";

import { MatSidenavModule } from "@angular/material/sidenav";
import { MatDialogModule, MatDialogRef } from "@angular/material/dialog";
import {HomeComponent} from "./home/home.component";
import {BrowserModule} from "@angular/platform-browser";
import {AppRoutingModule} from "../../app-routing.module";


@NgModule({
  declarations: [
    HomeComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    ToastrModule.forRoot(),
    HttpClientModule,
    MatIconModule,
    FormsModule,
    MatChipsModule,
    MatRadioModule,
    MatCheckboxModule,
    MatToolbarModule,
    MatButtonModule,
    MatSidenavModule,
    MatDialogModule
  ],
  providers: [
    {
      provide: MatDialogRef,
      useValue: {}
    },
  ],
  bootstrap: [HomeComponent]
})
export class HomeModule { }
