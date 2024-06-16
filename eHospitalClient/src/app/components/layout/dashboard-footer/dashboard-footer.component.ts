import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-dashboard-footer',
  standalone: true,
  imports: [],
  templateUrl: './dashboard-footer.component.html',
  styleUrl: './dashboard-footer.component.css'
})
export class DashboardFooterComponent implements OnInit{
  currentYear: number = 0;

  ngOnInit(): void {
    const currentDate = new Date();
    this.currentYear = currentDate.getFullYear();
  }
}
