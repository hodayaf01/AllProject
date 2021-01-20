import { ElementRef, Injectable, ViewChild } from '@angular/core';
import { AngularFireMessaging } from '@angular/fire/messaging';
import { BehaviorSubject } from 'rxjs'

@Injectable()
export class MessagingService {
  //@ViewChild (alertModal) alertModal:ElementRef;

  currentMessage = new BehaviorSubject(null);
  constructor(private angularFireMessaging: AngularFireMessaging) {
  //   this.angularFireMessaging.messaging.subscribe(
  //     (_messaging) => {
  //       _messaging.onMessage = _messaging.onMessage.bind(_messaging);
  //       _messaging.onTokenRefresh = _messaging.onTokenRefresh.bind(_messaging);
  //     })
   }
  requestPermission() {
    this.angularFireMessaging.requestToken.subscribe(
  (token) => {
    console.log(token);
  },
  (err) => {
    console.error('Unable to get permission to notify.', err);
  });
  }
  receiveMessage() {
    this.angularFireMessaging.messages.subscribe(
    (payload) => {
      console.log("new message received. ", payload);
      this.openNotificationScreen(payload);
      this.currentMessage.next(payload);
    })
  }

  openNotificationScreen(payload){

  }
}