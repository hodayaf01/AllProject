import {Component,OnInit} from '@angular/core';
import { User } from '../../Models/User.model';
import { Guardian } from '../../Models/Guardian.model';
@Component(
    {
        selector:'app-Settings',
        templateUrl:'./Setting.html',
        styleUrls:['./Setting.css']
    })
    export class SettingsComponent implements OnInit {
    ngOnInit() {
        alert("Method implemented.");
    }
        user:User=new User();
        guardians:Array<Guardian> =[];
        subscribe:any;
        constructor(private s){}


    }