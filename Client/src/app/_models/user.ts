import {TeamInvite} from "./teamInvite";
import {DuelInvite} from "./duelInvite";
import {Team} from "./team";

export interface User {
  id: string;
  username: string;
  token: string;
  nickname: string;
  team: Team;
  race: string;
  role: string;
  teamInvites: TeamInvite[];
  duelInvites: DuelInvite[];
}
