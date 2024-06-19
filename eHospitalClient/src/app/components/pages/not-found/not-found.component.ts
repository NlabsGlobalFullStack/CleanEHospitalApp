import { Component, OnInit } from '@angular/core';
import { TitleService } from '../../../services/title.service';

@Component({
  selector: 'app-not-found',
  standalone: true,
  imports: [],
  templateUrl: './not-found.component.html',
  styleUrl: './not-found.component.css'
})
export class NotFoundComponent implements OnInit{

  constructor(private title: TitleService) { }

  ngOnInit(): void {
    this.title.setPrefix('');
    this.title.setPageTitle('Page Not Found');
  }
}