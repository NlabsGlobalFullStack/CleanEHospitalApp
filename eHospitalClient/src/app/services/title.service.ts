import { Injectable } from '@angular/core';
import { Title } from '@angular/platform-browser';

@Injectable({
  providedIn: 'root'
})
export class TitleService {
  private prefix = 'NLabs Hospital | ';
  constructor(private titleService: Title) { }
  setPageTitle(title: string){
    const fullTitle = `${this.prefix}${title}`;
    this.titleService.setTitle(fullTitle);
  }
  
  setPrefix(prefix: string) {
    this.prefix = prefix;
  }
}
