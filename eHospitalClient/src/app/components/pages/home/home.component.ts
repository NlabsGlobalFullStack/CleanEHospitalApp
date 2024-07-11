import { Component, OnInit } from '@angular/core';
import { FooterComponent } from "../../layout/footer/footer.component";
import { DepartmentModel } from '../../../models/department.model';
import { ServiceModel } from '../../../models/service.model';
import { FaqModel } from '../../../models/faq.model';
import { SliderModel } from '../../../models/slider.model';
import { SettingsModel } from '../../../models/settings.model';
import { RouterLink } from '@angular/router';
import { AnnouncementModel } from '../../../models/announcement.model';
import { DatePipe, NgStyle } from '@angular/common';
import { DoctorModel } from '../../../models/doctor.model';
import { HttpService } from '../../../services/http.service';
import { TitleService } from '../../../services/title.service';
import { DomSanitizer, SafeHtml } from '@angular/platform-browser';
import { api } from '../../../constants';


@Component({
    selector: 'app-home',
    standalone: true,
    templateUrl: './home.component.html',
    styleUrl: './home.component.css',
    imports: [FooterComponent, RouterLink, DatePipe, NgStyle]
})
export class HomeComponent implements OnInit{
    apiUrl: string = api;
    departments: DepartmentModel[] = [];
    doctors: DoctorModel[] = [];
    services: ServiceModel[] = [];
    faqs: FaqModel[] = [];
    sliders: SliderModel[] = [];
    announcements: AnnouncementModel[] = [];
    settings: SettingsModel = new SettingsModel();
    safeMapsCode!: SafeHtml;

    constructor(
        private http: HttpService,
        private title: TitleService,
        private sanitizer: DomSanitizer
    ) { }

    ngOnInit(): void {
        this.getDepartments();
        this.getDoctors();
        this.getServices();
        this.getFaqs();
        this.getSliders();
        this.getAnnouncements();
        this.getSettings();
        this.title.setPrefix("");
        this.title.setPageTitle("Nlabs Hospital Application");
    }


    getDepartments(): void {
        this.http.post<DepartmentModel[]>("Home/GetDepartments", {}, (res) => {
            this.departments = res;
        });
    }

    getBackgroundImageUrl(image: string): string {
        if (!image) {
          return 'url("path_to_default_image")'; // Default bir resim yolu dönebilirsiniz
        }
        // Eğer image yolu tam bir URL değilse
        if (!image.startsWith('http')) {
          return `url("${this.apiUrl}/departments/${image.replace('/departments/', '')}")`;
        }
        return `url("${image}")`;
      }

    getDoctors() {
        this.http.post<DoctorModel[]>("Home/GetDoctors", {}, (res) => {
            this.doctors = res;
        });
    }

    getServices() {
        this.http.post<ServiceModel[]>("Home/GetServices", {}, (res) => {
            this.services = res;
        });
    }

    getFaqs() {
        this.http.post<FaqModel[]>("Home/GetFaqs", {}, (res) => {
            this.faqs = res;
        });
    }

    getSliders() {
        this.http.post<SliderModel[]>("Home/GetSliders", {}, (res) => {
            this.sliders = res;
        });
    }

    getAnnouncements() {
        this.http.post<AnnouncementModel[]>("Home/GetAnnouncmenets", {}, (res) => {
            this.announcements = res;
        });
    }

    getSettings() {
        this.http.post<SettingsModel>("Home/GetSettings", {}, (res) => {
            this.settings = res;
            this.safeMapsCode = this.sanitizer.bypassSecurityTrustHtml(this.settings.mapsCode);
            // <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3009.208239912099!2d29.00630807574685!3d41.04257501731289!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x14cab1115a3c0d87%3A0x96bde3e1e896cda2!2s%C4%B0stanbul%20E%C4%9Fitim%20Akademi!5e0!3m2!1str!2str!4v1714239014344!5m2!1str!2str" width="600" height="450" style="border:0;" allowfullscreen="" loading="lazy" referrerpolicy="no-referrer-when-downgrade"></iframe>
        });
    }
}
