import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { DashboardComponent } from './dashboard/dashboard.component';
import { ManagementuserComponent } from './managementuser/managementuser.component';
import { AccountsettingComponent } from './accountsetting/accountsetting.component';

const childRoutes: Routes = [
  { path: '', component: DashboardComponent },
  { path: 'management', component: ManagementuserComponent },
  { path: 'accountsettings', component: AccountsettingComponent },
]

@NgModule({
  imports: [RouterModule.forChild(childRoutes)],
  exports: [RouterModule],
})
export class ChildRoutesModule { }
