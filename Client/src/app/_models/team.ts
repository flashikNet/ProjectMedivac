import {User} from "./user";

export interface Team {
  id: string;
  teamName: string;
  members: User[];
}
