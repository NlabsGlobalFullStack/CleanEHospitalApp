import { Component, Input, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { TitleService } from '../../../services/title.service';

@Component({
  selector: 'app-layout',
  standalone: true,
  imports: [RouterOutlet],
  templateUrl: './layout.component.html',
  styleUrl: './layout.component.css'
})
export class LayoutComponent implements OnInit{
  constructor(private titleService: TitleService){}

  ngOnInit(): void {
    this.titleService.setPageTitle('');
  }
}
