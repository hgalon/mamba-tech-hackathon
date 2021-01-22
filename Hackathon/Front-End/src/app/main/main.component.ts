import { Component } from '@angular/core';

import { PoMenuItem, PoToolbarProfile, PoToolbarAction } from '@po-ui/ng-components';
import { AuthService } from '../core/auth/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html'
})
export class MainComponent {

  readonly profile: PoToolbarProfile = {
    subtitle: 'admin@demo.com.br',
    title: 'Admin'
  };

  readonly profileActions: Array<PoToolbarAction> = [
    { label: 'Sair', action: this.logout.bind(this) }
  ];

  readonly menus: Array<PoMenuItem> = [
    {
      label: 'Carreira',
      link: 'home',
      icon: 'po-icon-user',
      shortLabel: 'Carreira'
    }
  ];

  constructor(private authService: AuthService, private router: Router) {}

  private logout() {
    this.authService.logout();

    this.router.navigate(['/login']);
  }

}
