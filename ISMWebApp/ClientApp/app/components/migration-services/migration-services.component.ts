import { Component, OnInit } from '@angular/core';
import { IVisasCategory } from '../../models/visas-category';
import { VisasService } from '../../services/visas.service';

@Component({
  selector: 'app-migration-services',
  templateUrl: './migration-services.component.html',
  styleUrls: ['./migration-services.component.css']
})
export class MigrationServicesComponent implements OnInit {
  visas: IVisasCategory[] = [];

  constructor(private service: VisasService) { }

  ngOnInit() {
    this.service.getVisasCategory()
      .subscribe((res: IVisasCategory[]) => {
        this.visas = res;
        
      });
  }

}
