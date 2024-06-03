import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { AuthComponent } from './auth/auth.component';
import { TeamsComponent } from './teams/teams.component';
import { DuelsComponent } from './duels/duels.component';
import { DuelComponent } from './duel/duel.component';
import { TeamComponent } from './team/team.component';
import {HTTP_INTERCEPTORS, HttpClientModule} from "@angular/common/http";
import { RegisterComponent } from './register/register.component';
import { CreateTeamComponent } from './create-team/create-team.component';
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import { PlayerComponent } from './player/player.component';
import {JwtInterceptor} from "./_interceptors/jwt.interceptor";
import { InvitePlayerComponent } from './invite-player/invite-player.component';
import {ToastrModule} from "ngx-toastr";
import {BrowserAnimationsModule} from "@angular/platform-browser/animations";

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    AuthComponent,
    TeamsComponent,
    DuelsComponent,
    DuelComponent,
    TeamComponent,
    RegisterComponent,
    CreateTeamComponent,
    PlayerComponent,
    InvitePlayerComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot()
  ],
  providers: [
    {provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
