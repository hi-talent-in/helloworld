import { Component } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'my-app';

  
  constructor(private cookie: CookieService){

  }

  Name = '';
  getName(val)
  {
    console.warn(val)
    this.Name = 'Hello '+val.user;
    this.cookie.set("User",val.user)
    this.cookie.set("Pass",val.pass)

  }

  check()
  {
    let user = this.cookie.get("User");
    let pass = this.cookie.get("Pass");
    console.log(user+": "+pass)
    if(user.length>0 && pass.length>0)
    {
      alert("Hello " + user + " you are authenticated");
    }
    else{
      alert("Get Logged in you are not authenticated");
    }
  }


}
