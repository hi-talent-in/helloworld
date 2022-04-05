import { Component } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'frontend';
  constructor(private cookie: CookieService){
  }
  name = '';
  flag = false;
  getname(value: any){
    this.flag = false;
    if(value.user) {
      this.name = 'Hello '+value.user+'!';
      this.cookie.set("username",value.user);
    }
    else {
      this.name = 'Hello World!';
      alert("Enter username to store cookie.!");
    }
  }
  auth(value: any){
    let user = this.cookie.get("username");
    if(value.user==user){
      this.flag = true;
      this.name = 'Hello '+value.user+'!';
    }
    else{
      if(value.user=='') alert("Enter username to Authenticate.!");
      else alert("Authentication false..!");
    }
  }
}
