import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ICourseInstitute } from '../../models/course-institute';

@Component({
  selector: 'app-enroll-form',
  templateUrl: './enroll-form.component.html',
  styleUrls: ['./enroll-form.component.css']
})
export class EnrollFormComponent implements OnInit {
  @Input('course') course: string;
  @Input('institutes') institutes: ICourseInstitute[] = [];
  form: FormGroup;
  ischecked: boolean = false;
  @Output('cancel') cancel = new EventEmitter<boolean>();

  constructor(private fb: FormBuilder) {}

  ngOnInit() {
    console.log(this.institutes);
    
    this.form = this.fb.group({
      'name': [null, Validators.required],
      'email': [null, Validators.compose([Validators.required, Validators.email])],
      'number': [null, Validators.required],
      'course': [this.course, Validators.required],
      'institute': [null, Validators.required]
    });
    this.fullForm();
  }

  submit() {
    console.log(this.form.value);
    
  }

  reset() {
    this.form.reset();
    this.form.get('course').setValue(this.course);
  }

  toggleform(checked: boolean) {
    console.log(checked);
    this.ischecked = checked;
    if (checked) {
      this.basicForm();
    } else {
      this.fullForm();
    }
  }

  fullForm() {
    this.form = this.fb.group({
      'name': [this.form.value.name, Validators.required],
      'email': [this.form.value.email, Validators.compose([Validators.required, Validators.email])],
      'number': [this.form.value.number, Validators.required],
      'course': [this.form.value.course, Validators.required],
      'institute': [this.form.value.institute, Validators.required],
      'passport': this.fb.group({
        'number': [null, Validators.required],
        'countryIssue': [null, Validators.required],
        'expiryDate': [null, Validators.required],
        'issueDate': [null, Validators.required]
      }),
      'studentDetails': this.fb.group({
        'street': [null, Validators.required],
        'suburb': [null, Validators.required],
        'state': [null, Validators.required],
        'postcode': [null],
        'country': [null, Validators.required]
      })
    });
  }
  
  basicForm() {
    this.form = this.fb.group({
      'name': [this.form.value.name, Validators.required],
      'email': [this.form.value.email, Validators.compose([Validators.required, Validators.email])],
      'number': [this.form.value.number, Validators.required],
      'course': [this.form.value.course, Validators.required],
      'institute': [this.form.value.institute, Validators.required]
    });
  }

}
