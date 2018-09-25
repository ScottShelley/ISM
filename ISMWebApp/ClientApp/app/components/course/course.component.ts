import { Component, OnInit } from '@angular/core';
import { ICourse } from '../../models/course';
import { CourseService } from '../../services/course.service';
import { ActivatedRoute } from '@angular/router';
import { ICourseInstitute } from '../../models/course-institute';

@Component({
  selector: 'app-course',
  templateUrl: './course.component.html',
  styleUrls: ['./course.component.css']
})
export class CourseComponent implements OnInit {
  private id;
  course: ICourse;
  isTab: boolean[] = [true, false, false, false];
  isInstitutes: boolean[] = [];
  isEnrolPress: boolean = false;

  constructor(private service: CourseService, private route: ActivatedRoute) {
    this.id = this.route.snapshot.paramMap.get('id');
  }

  ngOnInit() {
    this.service.getById(this.id)
      .subscribe((res: ICourse) => {
        console.log(res);
        this.course = res;

        if (this.course) {
          this.service.getCourseInstituteById(this.id)
            .subscribe((ciRes: ICourseInstitute[]) => {
              this.course.courseInstitute = ciRes;
              console.log(this.course);
              this.course.courseInstitute.forEach(element => {
                this.isInstitutes.push(false);
              });
            });
        }
      });
  }

  changeTab(index: number) {
    this.isTab = [false, false, false, false];
    this.isTab[index] = true;
  }

}
