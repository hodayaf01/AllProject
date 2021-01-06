import { BrowserModule } from '@angular/platform-browser';
import { NgModule, Component } from '@angular/core'
import { FormsModule,ReactiveFormsModule } from '@angular/forms'
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {HttpClientModule} from '@angular/common/http';
import {RegistrationService} from './Services/RegistrationService';
import {RegistrationUserComponent} from './Components/RegistrationUser/RegistrationUser';
import { RouterModule, Routes } from '@angular/router';
import { TimeOfAlertComponent } from './Components/TimeOfAlert/TimeOfAlert';
import { TimeOfAlertForUserService } from './Services/TimeOfDayForUser.service';
import { SettingsComponent } from './Components/Settings/Settings';
import { SettingsService } from './Services/SettingsService';
import { HomeComponent } from './Components/Home/Home';
import { AlertComponent } from './Components/Alert/Alert';
import { AlertService } from './Services/AlertService';
import { HomeService } from './Services/HomeService'
import { PortalComponent } from './Components/Portal/Portal';

const appRoutes: Routes = [
  {path: 'Registration', component: RegistrationUserComponent},
  {path: 'TimeOfAlert', component: TimeOfAlertComponent},
  {path:'Settings',component:SettingsComponent},
  {path:'Home',component:HomeComponent},
  {path:'Alert',component:AlertComponent},
  {path:'Portal',component:PortalComponent}
];


@NgModule({
  declarations: [
    //כל קומפוננטה חייבת להיות כאן
    AppComponent, 
    RegistrationUserComponent,
    TimeOfAlertComponent,
    SettingsComponent,
    HomeComponent,
    AlertComponent,
    PortalComponent
  ],
  
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
    RouterModule.forRoot(appRoutes)
  ],

  //מכיל את כל הסרויסים
  providers: [
    RegistrationService,
    TimeOfAlertForUserService,
    SettingsService,
    AlertService,
    HomeService
  ],
  
  bootstrap: [AppComponent]
})
export class AppModule { }
