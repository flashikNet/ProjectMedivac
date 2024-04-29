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
import {HttpClientModule} from "@angular/common/http";
import { RegisterComponent } from './register/register.component';
import { CreateTeamComponent } from './create-team/create-team.component';
import {FormsModule} from "@angular/forms";
import { PlayerComponent } from './player/player.component';

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
    PlayerComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
