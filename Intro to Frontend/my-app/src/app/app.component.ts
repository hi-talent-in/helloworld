import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'my-app';

  Name = '';
  getName(val)
  {
    console.warn(val)
    this.Name = 'Hello '+val.user;
  }
}
