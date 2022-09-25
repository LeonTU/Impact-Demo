import { AuthService } from './../services/auth.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {
  userName!: string;
  isLogin = false;
  inputUser = '';

  constructor(private authService: AuthService) { }

  ngOnInit(): void {
    this.authService.auth$.subscribe(
      auth => {
        if (auth) {
          this.userName = auth.userName;
          this.isLogin = true;
        } else {
          this.userName = 'Guest';
          this.isLogin = false;
        }
      }
    );
  }

  buttonClicked() {
    if (this.isLogin) {
      this.authService.logout();
    } else {
      this.authService.login(this.inputUser);
    }
    this.inputUser = '';
  }
}
