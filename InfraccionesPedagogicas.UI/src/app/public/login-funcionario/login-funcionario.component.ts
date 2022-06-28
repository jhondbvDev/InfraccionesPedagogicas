import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login-funcionario',
  templateUrl: './login-funcionario.component.html',
  styleUrls: ['./login-funcionario.component.scss']
})
export class LoginFuncionarioComponent implements OnInit {

  constructor(private router : Router) { }

  ngOnInit() {
  }

  authenticate() {
    this.router.navigateByUrl("sm/dashboard");
  }
}
