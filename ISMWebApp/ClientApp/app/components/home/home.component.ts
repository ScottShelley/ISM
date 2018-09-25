import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs/Subscription';
import { TimerObservable } from "rxjs/observable/TimerObservable";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  slides: boolean[] = [false, false, false]

  private slideIndex: number = 1;
  private timeE: number = 5;
  private subscription: Subscription;

  constructor() { }

  ngOnInit() {
    this.showSlides();

    let timer = TimerObservable.create(2000, 1000);
    this.subscription = timer.subscribe(t => {
      if (t === this.timeE) {
        this.timeE += 5;
        this.slideIndex += 1;
        this.showSlides();
      }
    });
  }

  plusSlides(index: number) {
    this.subscription.unsubscribe();
    this.slideIndex += index;
    this.showSlides();
  }

  currentSlide(index: number) {
    this.subscription.unsubscribe();
    this.slideIndex = index;
    this.showSlides();
  }

  private showSlides() : void {
    let i;
    if (this.slideIndex > this.slides.length) { this.slideIndex = 1; }
    if (this.slideIndex < 1) { this.slideIndex = this.slides.length; }

    for (i = 0; i < this.slides.length; i++) {
      this.slides[i] = false;
    }

    this.slides[this.slideIndex-1] = true;
  }

}
