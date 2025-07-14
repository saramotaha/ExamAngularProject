import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { ExamService } from '../../Services/exam-service';
import{IExam}from '././../../Interfaces/iexam'
import { ActivatedRoute, Router, RouterLink } from '@angular/router';



@Component({
  selector: 'app-exam',
  imports: [RouterLink],
  templateUrl: './exam.html',
  styleUrls: ['./exam.css'],
  standalone: true

})
export class Exam implements OnInit{
  Exams: IExam[] = []
  ExamDeletedId!: number;

 ExamId!: any;

  constructor(private exam: ExamService ,private CDR:ChangeDetectorRef ,private router:Router , private route:ActivatedRoute) { }

  AllExams() {
    this.exam.GetAllExams().subscribe({
      next: (response) => {
        this.Exams = response as IExam[];
        console.log(this.Exams);
      }
    });


  }


   DeleteExam(id:number) {
      this.exam.DeleteExam(id).subscribe({
        next: (response: any) => {

          this.AllExams();
          this.CDR.detectChanges();
        //  this.Exams = this.Exams.filter(e => e.id !== id);


      }

      })

  }








  ngOnInit(): void {

    this.AllExams();
    // this.ExamId =this.route.snapshot.paramMap.get('id');
  }



  AddQuestion(examId: any) {
  this.ExamId=examId;
    this.router.navigate([`/AddQuestion/${examId}`]);
  }




}
