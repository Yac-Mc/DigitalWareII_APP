import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { SharedModule } from '../shared/shared.module';

import { PagesComponent } from './pages.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { ManagementuserComponent } from './managementuser/managementuser.component';
import { AccountsettingComponent } from './accountsetting/accountsetting.component';

@NgModule({
  declarations: [
    PagesComponent,
    DashboardComponent,
    ManagementuserComponent,
    AccountsettingComponent
  ],
  exports:[
    PagesComponent,
    DashboardComponent,
    ManagementuserComponent,
    AccountsettingComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    RouterModule
  ]
})
export class PagesModule { }
