import { Component, OnInit } from '@angular/core';
import {AccountService} from "../_services/account.service";
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {Router} from "@angular/router";

@Component({
  selector: 'app-register',
  templateUrl: './auth.component.html',
  styleUrls: ['./auth.component.less']
})
export class AuthComponent implements OnInit {
  registerForm: FormGroup = this.fb.group({})

  constructor(
    private fb: FormBuilder,
    private accountService: AccountService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.registerForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(6)]]
    });
  }



  onSubmit(): void {
    if (this.registerForm.valid) {
      const formData = this.registerForm.value;
      console.log(formData)
      this.accountService.login(formData).subscribe(
        response => {
          console.log('Login successful', response);
          this.router.navigateByUrl('/');
        },
        error => {
          console.error('Login failed', error);
        }
      );
    }
  }
}
