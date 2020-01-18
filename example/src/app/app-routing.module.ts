import { NgModule } from '@angular/core';
import {  RouterModule,Routes } from '@angular/router';
import { RegistrationUserComponent } from './Components/RegistrationUser/RegistrationUser';
import { TimeOfAlertComponent } from './Components/TimeOfAlert/TimeOfAlert';
import { SettingsComponent } from './Components/Settings/Settings';
import { HomeComponent } from './Components/Home/Home';


export const appRoutes: Routes = [
  {path:'RegistrationUser', component:RegistrationUserComponent},
  {path:'TimeOfAlert', component:TimeOfAlertComponent},
  {path:'Settings',component:SettingsComponent},
  {path: 'Home', component:HomeComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(appRoutes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
//נותנים שם לפי השם של הטס בקומפוננטה ומציגים יואראך מתאים