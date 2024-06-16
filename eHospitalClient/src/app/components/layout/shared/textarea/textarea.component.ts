import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-textarea',
  standalone: true,
  imports: [],
  templateUrl: './textarea.component.html',
  styleUrl: './textarea.component.css'
})
export class TextareaComponent {
  @Input() label: string = 'Full Address';
  @Input() name: string = 'fullAddress';
  @Input() rows: number = 3;
  @Input() value?: string;
}
