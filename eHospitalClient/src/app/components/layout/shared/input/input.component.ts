import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-input',
  standalone: true,
  imports: [],
  templateUrl: './input.component.html',
  styleUrl: './input.component.css'
})
export class InputComponent {
  @Input() name: string = 'firstName';
  @Input() type: string = 'text';
  @Input() label: string = 'Identity Number';
  @Input() value?: string;
}
