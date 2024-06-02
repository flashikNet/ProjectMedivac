import { Component, OnInit } from '@angular/core';
import {AccountService} from "../_services/account.service";
import {AbstractControl, FormBuilder, FormGroup, ValidationErrors, ValidatorFn, Validators} from "@angular/forms";
import {Router} from "@angular/router";

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.less']
})
export class RegisterComponent implements OnInit {
  registerForm: FormGroup = this.fb.group({})

  constructor(
    private fb: FormBuilder,
    private accountService: AccountService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.registerForm = this.fb.group({
      username: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(6)]],
      nickname: ['', Validators.required],
      race: ['Terran', Validators.required]
    });
  }



  onSubmit(): void {
    if (this.registerForm.valid) {
      const formData = this.registerForm.value;
      console.log(formData)
      this.accountService.register(formData).subscribe(
        response => {
          console.log('Registration successful', response);
          this.router.navigateByUrl('/');
        },
        error => {
          console.error('Registration failed', error);
        }
      );
    }
  }
}
