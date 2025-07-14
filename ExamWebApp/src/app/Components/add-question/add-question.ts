import { Component, OnInit } from '@angular/core';
import { FormArray, FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { AddQuestionService } from '../../Services/add-question-service';
import { IQuestion } from '../../Interfaces/iquestion';
import { ActivatedRoute, Router } from '@angular/router';


@Component({
  selector: 'app-add-question',
    standalone:true,
  imports: [ReactiveFormsModule ],
  templateUrl: './add-question.html',
  styleUrl: './add-question.css',

})
export class AddQuestion implements OnInit {


  QuestionBody: {}={};
  id!: number;
  correctAnswer: string = '';
  QuestionForm!: FormGroup;
  constructor(private AddQues: AddQuestionService, private route: ActivatedRoute) {
  }

  ngOnInit(): void {
    this.id = +this.route.snapshot.paramMap.get('id')!;
    console.log(this.id);






 this.QuestionForm = new FormGroup({

    examId:new FormControl(this.id),
    text:new FormControl(''),
   degree: new FormControl(''),
   optionA: new FormControl(''),
   optionB: new FormControl(''),
   optionC: new FormControl(''),
   correctAnswer: new FormControl(''),

  })
  }





  getOptions(): FormGroup{

    return this.QuestionForm.get('options')  as FormGroup;

  }



  SaveQuestion() {

    var options= [
      {"answerText": this.QuestionForm.value.optionA,
        "isCorrect": this.correctAnswer === '1',
      }
      ,
      {"answerText": this.QuestionForm.value.optionB,
        "isCorrect": this.correctAnswer === '2',
      }
      ,
       {"answerText":this.QuestionForm.value.optionC,
         "isCorrect": this.correctAnswer === '3',
       }
    ]


     this.QuestionBody = {
    examId:this.QuestionForm.value.examId,
    text:this.QuestionForm.value.text,
    degree:this.QuestionForm.value.degree ,
    choices:options,

    }

    if (this.QuestionForm.valid) {

      console.log(this.QuestionBody);
      this.AddQues.AddQuestions(this.QuestionBody as IQuestion);



    }

    else {
      console.log("Not valid");

    }


  }

}













 ///  choices: new FormArray([
  ///    new FormGroup(
  //       {

  //   answerText:new FormControl(''),
  //   isCorrect:new FormControl(''),

  //   }
  //    ),
  //    new FormGroup(
  //     {

  //   answerText:new FormControl(''),
  //   isCorrect:new FormControl(''),

  //   }
  //   ),
  //    new FormGroup(
  //     {

  //   answerText:new FormControl(''),
  //   isCorrect:new FormControl(''),

  //   }
  //   )
  ////   ])
