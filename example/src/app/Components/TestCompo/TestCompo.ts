import {  Component, OnInit } from '@angular/core';

@Component({
    selector: 'app-test-compo',
    templateUrl: './TestCompo.html',
})

export class TestComponent implements OnInit{
    constructor() { }
    ngOnInit(){
        console.log("Test Component");
    }
}
