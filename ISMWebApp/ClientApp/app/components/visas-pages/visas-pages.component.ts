import { Component, OnInit, HostBinding } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { VisasService } from '../../services/visas.service';
import { IVisasPage } from '../../models/visas-category';

@Component({
  selector: 'app-visas-pages',
  templateUrl: './visas-pages.component.html',
  styleUrls: ['./visas-pages.component.css']
})
export class VisasPagesComponent implements OnInit {
  url: string;
  visa: IVisasPage = {
    url: '',
    title: '',
    description: '',
    imgUrl: '',
    visas: []
  };
  isSelected: boolean[] = [];

  constructor(private route: ActivatedRoute, private router: Router, private service: VisasService) {
    this.url = this.route.snapshot.paramMap.get('url');
  }

  ngOnInit() {
    console.log(this.url);
    this.service.getVisasByUrl(this.url)
      .subscribe((res: IVisasPage) => {
        this.visa = res;
        console.log(this.visa.visas);
        this.visa.visas.forEach(element => {
          this.isSelected.push(false);
        });
      });

    // this.service.getVisaPage(this.page)
    //   .subscribe((res: IVisasPage) => {
    //     this.seoService.generateTags({
    //       title: res.title + ' | Northwestern Institute',
    //       description: res.description,
    //       image: res.imgurl,
    //       url: '/visas/' + this.page
    //     });
    //     this.visa = res;
    //     res.htmlcontexts.forEach(element => {
    //       this.isSelected.push(false);
    //     });
    //   });
  }

}
