import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {AuthComponent} from "./auth/auth.component";
import {DuelsComponent} from "./duels/duels.component";
import {DuelComponent} from "./duel/duel.component";
import {TeamsComponent} from "./teams/teams.component";
import {TeamComponent} from "./team/team.component";
import {RegisterComponent} from "./register/register.component";
import {CreateTeamComponent} from "./create-team/create-team.component";
import {PlayerComponent} from "./player/player.component";
import {InvitePlayerComponent} from "./invite-player/invite-player.component";

const routes: Routes = [
  { path: 'auth', component: AuthComponent },
  { path: 'duels', component: DuelsComponent},
  { path: 'duels/:id', component: DuelComponent},
  { path: 'teams', component: TeamsComponent},
  { path: 'teams/:id', component: TeamComponent},
  { path: 'register', component: RegisterComponent},
  { path: 'create-team', component: CreateTeamComponent},
  { path: 'invite-player', component: InvitePlayerComponent},
  { path: 'players/:id', component: PlayerComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
