import { NgModule } from '@angular/core';
import {  RouterModule,Routes } from '@angular/router';
import { RegistrationUserComponent } from './Components/RegistrationUser/RegistrationUser';
import { TimeOfAlertComponent } from './Components/TimeOfAlert/TimeOfAlert';
import { SettingsComponent } from './Components/Settings/Settings';
import { AlertComponent } from './Components/Alert/Alert';


export const appRoutes: Routes = [
  {path:'RegistrationUser', component:RegistrationUserComponent},
  {path:'TimeOfAlert', component:TimeOfAlertComponent},
  {path:'Settings',component:SettingsComponent}
  {path:'Alert',component:AlertComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(appRoutes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
//נותנים שם לפי השם של הטס בקומפוננטה ומציגים יואראך מתאים