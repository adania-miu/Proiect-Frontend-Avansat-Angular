import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from "@angular/forms";
import { equalToValidator } from "../../../../directives/equal-to.directive";
import { AccountService } from "../../services/account.service";
import {IUserSignup, rolesAtLeast} from "../../../../models/user";
import { Router } from "@angular/router";
import { ToastrService } from "ngx-toastr";
@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.scss']
})
export class SignupComponent implements OnInit {
  formGroup: FormGroup = new FormGroup({
    'username': new FormControl('', Validators.required),
    'firstName': new FormControl('', Validators.required),
    'lastName': new FormControl('', Validators.required),
    'email': new FormControl('', [Validators.required, Validators.email]),
    'password': new FormControl('', Validators.required),
    'passwordConfirmation': new FormControl('', Validators.required),
    'role': new FormControl( 'User'),
  });
  errors: string[] = [];
  isLoading: boolean = false;

  constructor(
    private accountsService: AccountService,
    private router: Router,
    private toastr: ToastrService
  )
  {
    this.formGroup.get('passwordConfirmation')?.addValidators(equalToValidator(this.formGroup.get('password')!));
  }

  ngOnInit(): void { }

  signup(): void {
    this.isLoading = false;
    this.accountsService.signUp(this.formGroup.value as IUserSignup).subscribe({
      next: (_) => {
          console.log('Account created!');
          //this.isLoading = false;
          //this.toastr.success('Account created successfully.');
          this.router.navigate(['/login']);
        }
        // ,
        // error: (res: any) => {
        //   this.isLoading = false;
        //   this.errors = res.error.map((e: any) => e.description);
        // }
      });
  }
}
