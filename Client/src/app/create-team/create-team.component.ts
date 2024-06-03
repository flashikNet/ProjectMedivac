import {Component} from '@angular/core';
import {TeamsService} from "../_services/teams.service";
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {AccountService} from "../_services/account.service";
import {Router} from "@angular/router";

@Component({
  selector: 'app-create-team',
  templateUrl: './create-team.component.html',
  styleUrls: ['./create-team.component.less']
})
export class CreateTeamComponent {
  createTeamForm: FormGroup = this.fb.group({})
  error: string = "";

  constructor(
    private fb: FormBuilder,
    private teamService: TeamsService,
    private router: Router
  ) {
  }

  ngOnInit(): void {
    this.createTeamForm = this.fb.group({
      teamName: ['', Validators.required]
    });
  }


  onSubmit(): void {
    if (this.createTeamForm.valid) {
      const formData = this.createTeamForm.value;
      console.log(formData)
      this.teamService.createTeam(formData).subscribe(
        response => {
          console.log('Create Team successful', response);
          this.router.navigateByUrl('/');
        },
        error => {
          console.error('Create Team failed', error);
          this.error = error.error;
        }
      );
    }
  }
}
