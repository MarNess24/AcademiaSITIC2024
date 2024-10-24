import { Component } from '@angular/core';

@Component({
  selector: 'app-counter',
  standalone: true,
  imports: [],
  templateUrl: './counter.component.html',
  styleUrl: './counter.component.css'
})
export class CounterComponent {
  counter: number = 10;

  incrementar() {
    this.counter++;
  }

  decrementar() {
    this.counter--;
  }

  reset() {
    this.counter = 10;
  }
}
