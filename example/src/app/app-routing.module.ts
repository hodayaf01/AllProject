import { NgModule } from '@angular/core';
import {  RouterModule,Routes } from '@angular/router';
import { RegistrationUserComponent } from './Components/RegistrationUser/RegistrationUser';
import { TimeOfAlertComponent } from './Components/TimeOfAlert/TimeOfAlert';
import { SettingsComponent } from './Components/Settings/Settings';
import { HomeComponent } from './Components/Home/Home';
import { AlertComponent } from './Components/Alert/Alert';
import { PortalComponent } from './Components/Portal/Portal';
import { MedicinesListComponent } from './Components/MedicinesList/MedicinesList';
import { PasswordVereficationComponent } from './Components/PasswordVerefication/PasswordVerefication';
import { GuideComponent } from './Components/Guide/Guide';
import { TermsOfUseComponent } from './Components/TermsOfUser/TermsOfUser';


export const appRoutes: Routes = [
  {path:'RegistrationUser', component:RegistrationUserComponent},
  {path:'TimeOfAlert', component:TimeOfAlertComponent},
  {path:'Settings',component:SettingsComponent},
  {path: 'Home', component:HomeComponent},
  {path:'Alert/:id/:time',component:AlertComponent},
  {path:'Portal',component:PortalComponent},
  {path:'MedicinesList',component:MedicinesListComponent},
  {path:'PasswordVerefication',component:PasswordVereficationComponent},
  {path: 'Guide', component: GuideComponent},
  {path: 'TermsOfUse', component: TermsOfUseComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(appRoutes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
//נותנים שם לפי השם של הטס בקומפוננטה ומציגים יואראך מתאים