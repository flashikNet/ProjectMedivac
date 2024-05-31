import {TeamInvite} from "./teamInvite";
import {DuelInvite} from "./duelInvite";
import {Team} from "./team";

export interface User {
  username: string;
  token: string;
  nickname: string;
  team: Team;
  Race: Races;
  Role: Roles;
  TeamInvites: TeamInvite[];
  DuelInvites: DuelInvite[];
}
