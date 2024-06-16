import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-breadcrump',
  standalone: true,
  imports: [],
  templateUrl: './breadcrump.component.html',
  styleUrl: './breadcrump.component.css'
})
export class BreadcrumpComponent {
  @Input() title: string = 'Default Title';
}
