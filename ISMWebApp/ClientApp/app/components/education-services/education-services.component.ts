import { Component, OnInit } from '@angular/core';
import { CourseService } from '../../services/course.service';
import { ICourse } from '../../models/course';

@Component({
  selector: 'app-education-services',
  templateUrl: './education-services.component.html',
  styleUrls: ['./education-services.component.css']
})
export class EducationServicesComponent implements OnInit {
  course: ICourse[] = [];

  constructor(private services: CourseService) { }

  ngOnInit() {
    this.services.get().subscribe((res: ICourse[]) => {
      console.log(res);
      this.course = res;
    });
  }

}
