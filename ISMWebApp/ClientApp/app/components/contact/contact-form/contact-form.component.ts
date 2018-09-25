import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-contact-form',
  templateUrl: './contact-form.component.html',
  styleUrls: ['./contact-form.component.css']
})
export class ContactFormComponent implements OnInit {
  form: FormGroup;
  @Input('email') emailTo: string = "info@ismigration.com.au";

  constructor(private fb: FormBuilder) {
    this.form = fb.group({
      'name': [null, Validators.required],
      'email': [null, Validators.compose([Validators.required, Validators.email])],
      'phone': [null, Validators.required],
      'subject': [null, Validators.required],
      'message': [null, Validators.required]
    });
  }

  ngOnInit() {
    console.log(this.emailTo);
    
  }

  send() {
    console.log(this.form.value);
    
  }

  reset() {
    this.form.reset();
  }

}
