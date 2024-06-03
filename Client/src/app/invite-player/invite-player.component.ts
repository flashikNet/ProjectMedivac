import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import {ToastrService} from "ngx-toastr";

@Component({
  selector: 'app-invite-player',
  templateUrl: './invite-player.component.html',
  styleUrls: ['./invite-player.component.less']
})
export class InvitePlayerComponent implements OnInit {
  invitePlayerForm: FormGroup = this.formBuilder.group({});

  constructor(private formBuilder: FormBuilder, private toastr: ToastrService) { }

  ngOnInit(): void {
    this.invitePlayerForm = this.formBuilder.group({
      playerUsername: ['', Validators.required]
    });
  }

  onSubmit() {
    if (this.invitePlayerForm.valid) {
      console.log(this.invitePlayerForm.value);
      this.toastr.success('Игрок успешно приглашен!', '👍', {positionClass: 'toast-bottom-right'})
    }
  }
}
