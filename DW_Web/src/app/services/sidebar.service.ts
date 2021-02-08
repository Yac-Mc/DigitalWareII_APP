import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class SidebarService {
  menu: any[] = [
    {
      title: 'Dashboard',
      icon: 'mdi mdi-gauge',
      subMenu: [
        { title: 'Aeronaves', url: '/' },
        { title: 'Roles', url: 'management' }
      ],
    },
  ];
  constructor() {}
}
