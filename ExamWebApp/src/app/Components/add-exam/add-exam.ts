import { Component } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { ExamService } from '../../Services/exam-service';
import { log } from 'node:console';
import { IExam } from '../../Interfaces/iexam';
import { HttpBackend, HttpContext } from '@angular/common/http';

@Component({
  selector: 'app-add-exam',
  imports: [ReactiveFormsModule],
  templateUrl: './add-exam.html',
  styleUrl: './add-exam.css'
})
export class AddExam {

  constructor(private exam:ExamService){}

  registerForm=new FormGroup({

    name:new FormControl(),
    description:new FormControl(),
    duration:new FormControl(),
    totalScore:new FormControl(),
  })



  createExam(){

    if (this.registerForm.valid) {

      this.exam.AddExam(this.registerForm.value as IExam).subscribe({
        next: (response: any) => {
          console.log(response);

        }
      })



    }

}




}
